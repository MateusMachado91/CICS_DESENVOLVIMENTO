namespace PYBWeb.Infrastructure.Services
{
    public static class RegrasTabelas
    {
        // Regras para nome da fila
        public static bool ValidarNomeFila(string? nomeFila, string? css)
        {
            if (string.IsNullOrWhiteSpace(nomeFila))
                return false;

            // Regra 1: Deve ter exatamente 4 caracteres
            if (nomeFila.Length != 4)
                return false;

            // Regra 2: Não pode começar com 'C'
            if (nomeFila.StartsWith("C", StringComparison.OrdinalIgnoreCase))
                return false;

            // Regra 3: Se sistema for PCG
            if (css?.ToUpperInvariant() == "PCG")
            {
                if (!nomeFila.StartsWith("P", StringComparison.OrdinalIgnoreCase))
                    return false;

                // Últimos dois caracteres devem coincidir com os dois últimos do CSS
                if (nomeFila.Substring(2, 2).ToUpperInvariant() != css.Substring(css.Length - 2).ToUpperInvariant())
                    return false;
            }

            return true;
        }

        // Regras para DDNAME do tipo EXTRA
        public static bool ValidarDdnameExtra(string ddname)
        {
            if (string.IsNullOrWhiteSpace(ddname))
                return false;

            if (ddname.Equals("A,INTRDR", StringComparison.OrdinalIgnoreCase))
                return true;

            if (ddname.StartsWith("BPDcss", StringComparison.OrdinalIgnoreCase) &&
                ddname.Contains(".S") &&
                ddname.Contains(".G00000."))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Valida o tamanho do registro.
        /// Deve ser maior que 0 e menor que 32768.
        /// </summary>
        public static bool ValidarTamanhoRegistro(string? regSize)
        {
            if (string.IsNullOrWhiteSpace(regSize))
                return false;

            if (!int.TryParse(regSize, out int tamanho))
                return false;

            return tamanho > 0 && tamanho < 32768;
        }

        /// <summary>
        /// Valida o tamanho do bloco.
        /// Se BLOCK: 1 a 32767 | Se UNBLOCK: 0
        /// </summary>
        public static bool ValidarTamanhoBloco(string? blockSize, string? formReg2)
        {
            if (string.IsNullOrWhiteSpace(blockSize))
                return false;

            if (!int.TryParse(blockSize, out int tamanho))
                return false;

            if (formReg2?.ToUpperInvariant() == "BLOCK")
                return tamanho >= 1 && tamanho <= 32767;

            if (formReg2?.ToUpperInvariant() == "UNBLOCK")
                return tamanho == 0;

            return true;
        }

        // Regras para INTRA

        /// <summary>
        /// Valida a transação (campo de texto não vazio).
        /// </summary>
        public static bool ValidarTransacao(string? transacao)
        {
            return !string.IsNullOrWhiteSpace(transacao);
        }

        /// <summary>
        /// Valida o TrigLevel.
        /// Deve ser maior que zero.
        /// </summary>

        

        public static bool ValidarTrigLevel(int? trigLevel)
        {
            return trigLevel.HasValue && trigLevel.Value > 0;
        }


        /// <summary>
        /// Valida o destino.
        /// Deve ser "TERMINAL" ou "FILE".
        /// </summary>
        public static bool ValidarDestino(string? destino)
        {
            if (string.IsNullOrWhiteSpace(destino))
                return false;

            var valor = destino.ToUpperInvariant();
            return valor == "TERMINAL" || valor == "FILE";
        }

        /// <summary>
        /// Valida o terminal.
        /// Obrigatório se destino for TERMINAL.
        /// Deve ter exatamente 4 caracteres.
        /// </summary>
        public static bool ValidarTerminal(string? terminal, string? destino)
        {
            if (destino?.ToUpperInvariant() != "TERMINAL")
                return true; // Não precisa validar terminal se destino não for TERMINAL

            if (string.IsNullOrWhiteSpace(terminal))
                return false;

            return terminal.Length == 4;
        }
        
        public static bool ValidarFilaIntra(string? transacao, int? trigLevel, string? destino, string? terminal)
        {
            return ValidarTransacao(transacao)
                && ValidarTrigLevel(trigLevel)
                && ValidarDestino(destino)
                && ValidarTerminal(terminal, destino);
        }

        public static bool ValidarNomeTransacao(string? nameTrans, string? css)
        {
            if (string.IsNullOrWhiteSpace(nameTrans) || string.IsNullOrWhiteSpace(css) || css.Length < 2)
                return false;

            var ultimosDois = css.Substring(css.Length - 2);
            return nameTrans.StartsWith(ultimosDois, StringComparison.OrdinalIgnoreCase)
                || nameTrans.EndsWith(ultimosDois, StringComparison.OrdinalIgnoreCase);
        }

        public static bool ValidarProgramaParaAtivar(string? program, string? css)
        {
            if (string.IsNullOrWhiteSpace(program) || string.IsNullOrWhiteSpace(css))
                return false;

            program = program.ToUpperInvariant();
            css = css.ToUpperInvariant();

            // Verifica se começa com CSS + "P" ou "PWXP"
            return program.StartsWith(css + "P") || program.StartsWith("PWXP");
        }

        public static bool ValidarTwaSize(string? twaSize)
        {
            if (string.IsNullOrWhiteSpace(twaSize))
                return false;

            if (!int.TryParse(twaSize, out int valor))
                return false;

            return valor < 32768;
        }

        public static bool ValidarNomeArquivoFct(string? nameArq, string? css)
        {
            if (string.IsNullOrWhiteSpace(nameArq) || string.IsNullOrWhiteSpace(css))
                return false;
            var nomeArquivo = nameArq.ToUpperInvariant();
            var cssUpper = css.ToUpperInvariant();
            return nomeArquivo.StartsWith(cssUpper);
        }

        public static bool ValidarDsnameFct(string? dsnameArq, string? css)
        {
            if (string.IsNullOrWhiteSpace(dsnameArq) || string.IsNullOrWhiteSpace(css))
                return false;
            var dsname = dsnameArq.ToUpperInvariant();
            var cssUpper = css.ToUpperInvariant();
            return
                dsname.StartsWith("BPD" + cssUpper) &&
                dsname.Contains(".D") &&
                dsname.Contains(".G00000") &&
                !dsname.Contains("_");
        }
        
    }
}    