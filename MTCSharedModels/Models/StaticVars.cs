using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    internal static class StaticVars
    {
        public const string AlphaCheck = " !@#$%^&*()_+1234567890-=<>?,./:\";'[]{}\\|\n\r\v\b\f\a\t";
        public const string AlphaErrorFixMessage = "You can only have chars A-Z and a-z";

        public const string AlphaNumbericCheckWithDashes = " !@#$%^&*()+=<>?,./:\";'[]{}\\|\n\r\v\b\f\a\t";
        public const string AlphaNumbericErrorFixMessageWithDashes = "You can only have chars A-Z, a-z, 0-9, -, and _ ";

        public const string AlphaNumbericCheckWithDashesAndCommas = " !@#$%^&*()+=<>?/:\";'[]{}\\|\n\r\v\b\f\a\t";
        public const string AlphaNumbericErrorFixMessageWithDashesAndCommas = "You can only have chars A-Z, a-z, 0-9, ,, ., -, and _ ";

        public const string AlphaStartRegexCheck = "^[^0-9_-].*";
        public const string AlphaStartRegexCheckName = "Apha Start";
        public const string AlphaStartRegexErrorMessageExtend = "Please ensure that your user name starts with A-Z or a-z.";
    }
}
