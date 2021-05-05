using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using Mountain_Tracker_Climb___API.Models;
using MTCSharedModels.Models;

namespace Mountain_Tracker_Climb___API.Helpers
{
    public static class MiscellaneousHelpers
    {
        public static UserInfoPrivate ToPrivateUser(UserInfoPublic User)
        {
            return new UserInfoPrivate()
            {
                ID = User.ID,
                KeepPrivate = User.KeepPrivate,
                UserName = User.UserName
            };
        }

        public static UserInfoPublic ToPublicUser(UserFull User)
        {
            return new UserInfoPublic()
            {
                ID = User.ID,
                KeepPrivate = User.KeepPrivate,
                UserName = User.UserName,
                CountryID = User.CountryID,
                ProfileURL = User.ProfileURL,
                ProvinceID = User.ProvinceID,
                Bio = User.Bio,
                FirstName = User.FirstName,
                LastName = User.LastName,
                MiddleName = User.MiddleName
            };
        }

        internal static UserFull ToFullUser(UserFullWithSecurity User)
        {
            return new UserFull()
            {
                ID = User.ID,
                KeepPrivate = User.KeepPrivate,
                UserName = User.UserName,
                CountryID = User.CountryID,
                ProfileURL = User.ProfileURL,
                ProvinceID = User.ProvinceID,
                Bio = User.Bio,
                FirstName = User.FirstName,
                LastName = User.LastName,
                MiddleName = User.MiddleName,
                EmailValidated = User.EmailValidated,
                MetricOverImperial = User.MetricOverImperial,
                AccessLevelID = User.AccessLevelID,
                PhoneValidated = User.PhoneValidated,
                PrimaryPersonalEmail = User.PrimaryPersonalEmail,
                PrimaryPhone = User.PrimaryPhone,
                UserAccessLevel = User.UserAccessLevel
            };
        }
    }
}