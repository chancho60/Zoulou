using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zoulou.GData.Models {
    public class OAuth2Token {
        public readonly string AuthToken;
        public readonly DateTime Expiration;

        public OAuth2Token(string authToken, DateTime expiration) {
            AuthToken = authToken;
            Expiration = expiration;
        }
    }
}