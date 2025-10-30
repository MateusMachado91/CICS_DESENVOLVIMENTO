# Migration Notes - Removing INI Configuration and Usuario Entity

## Overview
This document describes the changes made to remove INI configuration support and the Usuario entity from the application, and to standardize SQLite database paths.

## Changes Made

### 1. Removed INI Configuration Support

**Deleted Files:**
- `PYBWeb.Domain/Entities/IniConfiguration.cs` - Entity class
- `PYBWeb.Domain/Interfaces/IIniConfigurationRepository.cs` - Repository interface
- `PYBWeb.Domain/Interfaces/IIniConfigurationService.cs` - Service interface

**Modified Files:**
- `PYBWeb.Infrastructure/Data/PYBWebDbContext.cs` - Removed DbSet<IniConfiguration> and related configuration

**Impact:**
- Any code that previously relied on INI configuration should now use appsettings.json or environment variables
- No implementation files existed in Infrastructure layer, so no service cleanup was needed

### 2. Removed Usuario Entity

**Deleted Files:**
- `PYBWeb.Domain/Entities/Usuario.cs` - Entity class
- `PYBWeb.Domain/Interfaces/IUsuarioRepository.cs` - Repository interface

**Modified Files:**
- `PYBWeb.Infrastructure/Data/PYBWebDbContext.cs` - Removed DbSet<Usuario> and seed data for admin user
- `PYBWeb.Domain/Interfaces/ILegacyDataMigrationService.cs` - Removed ImportarUsuariosAsync method

**Important Notes:**
- String fields like `UsuarioSolicitante`, `UsuarioCriacao`, `UsuarioAtualizacao`, and `UsuarioAlteracao` remain as simple string properties
- These fields now capture username strings directly from the authentication context
- No FK relationships to Usuario entity exist anymore
- If user management is needed in the future, consider implementing a different approach

### 3. Standardized SQLite Database Paths

**Created Files:**
- `PYBWeb.Infrastructure/Helpers/DataPathHelper.cs` - Utility class for database path management

**DataPathHelper Methods:**
```csharp
// Returns PastaData from config or defaults to "../DATA"
public static string GetPastaData(IConfiguration configuration)

// Returns full path to database file in DATA folder
public static string GetDatabasePath(IConfiguration configuration, string filename)

// Returns formatted SQLite connection string
public static string GetConnectionString(IConfiguration configuration, string filename)
```

**Modified Files:**
- `PYBWeb.Infrastructure/Services/AmbienteCicsService.cs` - Now uses DataPathHelper
- `PYBWeb.Infrastructure/Services/SolicitacoesCics2025Service.cs` - Now uses DataPathHelper
- `PYBWeb.Infrastructure/Data/AmbienteDbContextFactory.cs` - Now uses DataPathHelper
- `SeedAmbiente.cs` - Now uses DataPathHelper with configuration
- `CheckDatabase.cs` - Now uses DataPathHelper with configuration

**Removed Hardcoded Paths:**
- `E:\Mateus\Meus Documentos\PYB\DATA\...` (from SeedAmbiente.cs and CheckDatabase.cs)
- `Z:\CICS APP\PYB001 - SOLICITACOES\DATA\...` (from AmbienteDbContextFactory.cs)

### 4. Configuration

**PastaData Configuration:**
To specify a custom data folder, add to your appsettings.json:
```json
{
  "PastaData": "/custom/path/to/DATA"
}
```

Or set environment variable:
```
PastaData=/custom/path/to/DATA
```

If not specified, defaults to `../DATA` (relative to application directory).

### 5. Database Files

The following SQLite databases should be in the DATA folder:
- `ambiente.db` - Used by AmbienteCicsService
- `dados2025.db` - Used by SolicitacoesCics2025Service

## Testing Local Changes

1. **Configure PastaData** (optional):
   - Add to appsettings.json or set environment variable
   - Ensure DATA folder exists with required .db files

2. **Build the solution:**
   ```bash
   dotnet build PYBWeb.sln
   ```

3. **Run the application:**
   ```bash
   cd PYBWeb.Web
   dotnet run
   ```

4. **Test database utilities** (optional):
   - CheckDatabase.cs can be used to verify dados2025.db structure
   - SeedAmbiente.cs can be used to populate ambiente.db with initial data

## Migration Impact

### Breaking Changes
- Any code expecting `Usuario` entity will fail to compile
- Any code expecting `IniConfiguration` entity will fail to compile
- Hardcoded absolute paths to databases will no longer work

### Safe Changes
- String fields for user tracking (UsuarioSolicitante, etc.) continue to work
- Existing databases are not modified, only path resolution changed
- Configuration-based path resolution is more flexible for different environments

## TODO for Future Work

- Consider implementing a lightweight user/authentication service if user management features are needed
- Review any authorization logic that may have depended on Usuario entity properties (IsAdministrador, PodeAprovar)
- Update any documentation that references INI configuration or Usuario entity

## Rollback Instructions

If these changes need to be reverted:
1. Restore deleted files from git history
2. Revert changes to PYBWebDbContext.cs
3. Restore original hardcoded paths in service and utility files
4. Remove DataPathHelper.cs

The entities and configurations can be recovered from git history by checking out commits before this migration.
