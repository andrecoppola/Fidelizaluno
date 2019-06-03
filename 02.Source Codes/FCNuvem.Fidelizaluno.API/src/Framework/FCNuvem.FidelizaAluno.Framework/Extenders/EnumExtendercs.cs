using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FCNuvem.FidelizaAluno.Framework.Extenders
{
    public static class EnumExtender
    {
        public static string GetDescription(this Enum en)
        {
            var type = en.GetType();

            var memInfo = type.GetMember(en.ToString());

            if (memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return en.ToString();
        }

        public static bool TryParse<TEnum>(string value, out TEnum result) where TEnum : struct
        {
            if (string.IsNullOrWhiteSpace(value) ||
                !typeof(TEnum).IsEnum)
            {
                result = default(TEnum);
                return false;
            }

            if (Enum.TryParse(value, out result))
                return Enum.IsDefined(typeof(TEnum), result);

            return false;
        }

        public static TValue Covalente<TValue>(this Enum en, params (Enum EnumSelector, TValue Valor)[] itens)
        {
            foreach (var item in itens)
            {
                if (item.EnumSelector.Equals(en))
                    return item.Valor;
            }

            return default(TValue);
        }
    }
}
