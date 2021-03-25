using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Mountain_Tracker_Climb___API.Helpers
{
    [Flags]
    public enum RequireNumberFormat:byte
    {
        Any = 0xFF,
        NoSpaceSeperation = 0x00,
        DashOnlySeperation = 0x01,
        ParenthesesAndDashSeperation = 0x02,
        WhiteSpaceSeperation = 0x04,
    }

    public static class RegexHelpers
    {
        public static bool ValidEmailCheck(string ValueForEmail)
        {
            const string TheEmailPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";
            return Regex.IsMatch(ValueForEmail, TheEmailPattern);
        }

        /// <summary>
        /// NANP is the north amarican phone plan
        /// </summary>
        /// <param name="ValueForEmail"></param>
        /// <returns></returns>
        public static bool ValidNANPPhoneNumberWithWorldZone(string ValueForEmail, RequireNumberFormat Format = RequireNumberFormat.Any)
        {

            if (Format == RequireNumberFormat.Any)
            {
                const string TheEmailPattern = @"^[1]\s[0-9][0-9][0-9]\s[0-9][0-9][0-9]\s[0-9][0-9][0-9][0-9]$|^[1]-[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]$|^[1][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$|^[1]\([0-9][0-9][0-9]\)[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]$";
                return Regex.IsMatch(ValueForEmail, TheEmailPattern);
            }
            else
            {
                string TheEmailPattern = "";
                if ((Format & ~RequireNumberFormat.WhiteSpaceSeperation) == 0)
                {
                    TheEmailPattern += @"^[1]\s[0-9][0-9][0-9]\s[0-9][0-9][0-9]\s[0-9][0-9][0-9][0-9]$|";
                }
                if ((Format & ~RequireNumberFormat.ParenthesesAndDashSeperation) == 0)
                {
                    TheEmailPattern += @"^[1]\([0-9][0-9][0-9]\)[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]$|";
                }
                if ((Format & ~RequireNumberFormat.DashOnlySeperation) == 0)
                {
                    TheEmailPattern += @"^[1]-[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]$|";
                }
                if ((Format & ~RequireNumberFormat.NoSpaceSeperation) == 0)
                {
                    TheEmailPattern += @"^[1][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$|";
                }
                TheEmailPattern.Remove(TheEmailPattern.Length - 1, 1);
                return Regex.IsMatch(ValueForEmail, TheEmailPattern);
            }
        }

        /// <summary>
        /// NANP is the north amarican phone plan
        /// </summary>
        /// <param name="ValueForEmail"></param>
        /// <returns></returns>
        public static bool ValidNANPPhoneNumberWithoutWorldZone(string ValueForEmail, RequireNumberFormat Format = RequireNumberFormat.Any)
        {

            if (Format == RequireNumberFormat.Any)
            {
                const string TheEmailPattern = @"^[0-9][0-9][0-9]\s[0-9][0-9][0-9]\s[0-9][0-9][0-9][0-9]$|^[1]-[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]$|^[1][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$|^[1]\([0-9][0-9][0-9]\)[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]$";
                return Regex.IsMatch(ValueForEmail, TheEmailPattern);
            }
            else
            {
                string TheEmailPattern = "";
                if ((Format & ~RequireNumberFormat.WhiteSpaceSeperation) == 0)
                {
                    TheEmailPattern += @"^[0-9][0-9][0-9]\s[0-9][0-9][0-9]\s[0-9][0-9][0-9][0-9]$|";
                }
                if ((Format & ~RequireNumberFormat.ParenthesesAndDashSeperation) == 0)
                {
                    TheEmailPattern += @"^([0-9][0-9][0-9]\)[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]$|";
                }
                if ((Format & ~RequireNumberFormat.DashOnlySeperation) == 0)
                {
                    TheEmailPattern += @"^[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]$|";
                }
                if ((Format & ~RequireNumberFormat.NoSpaceSeperation) == 0)
                {
                    TheEmailPattern += @"^[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$|";
                }
                TheEmailPattern.Remove(TheEmailPattern.Length - 1, 1);
                return Regex.IsMatch(ValueForEmail, TheEmailPattern);
            }
        }
    }
}