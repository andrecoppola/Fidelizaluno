using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FCNuvem.FidelizaAluno.Framework.Extenders
{
    public static class EnvironmentHelper
    {
        public static bool Desenvolvimento => CheckAmbientType("Development", nameof(Desenvolvimento));
        public static bool Homologacao => CheckAmbientType("Homologação");
        public static bool Producao => CheckAmbientType("Production", "Produção");

        private static string[] EnvVarirableNames = new[] { "ASPNETCORE_ENVIRONMENT", "WEBJOB_ENVIRONMENT" };

        private static bool CheckAmbientType(params string[] nomes) =>
            EnvVarirableNames.Select(e => Environment.GetEnvironmentVariable(e))
                .Where(e => !string.IsNullOrWhiteSpace(e))
                .Select(e => NormalizeName(e))
                .Any(e => nomes.Select(n => NormalizeName(n)).Any(n => n == e));


        private static string NormalizeName(string name) =>
            Regex.Replace(name.RemoveAccentuation(), "\\s", "");
    }
}
