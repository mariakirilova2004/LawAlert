using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAlert.Infrastructure.Data
{
    public class DataConstants
    {
        //Constants, which are used for the implementation of the User
        public class User
        {
            public const int UserMinLengthFirstName = 3;
            public const int UserMaxLengthFirstName = 30;

            public const int UserMinLengthLastName = 3;
            public const int UserMaxLengthLastName = 30;

            public const int UserMinLengthUsername = 3;
            public const int UserMaxLengthUsername = 30;

            public const int UserMinLengthPassword = 6;
            public const int UserMaxLengthPassword = 18;

            public const int UserLengthPhoneNumber = 10;
        }

        public class Law
        {
            public const int LawMinLengthName = 5;
            public const int LawMaxLengthName = 50;

            public const int LawMinLengthDetails = 0;
            public const int LawMaxLengthDetails = 10000;
        }

        public class Article
        {
            public const int ArticleMinLengthDetails = 20;
            public const int ArticleMaxLengthDetails = 500;
        }

        public class Interest
        {
            public const int InterestMinLengthType = 5;
            public const int InterestMaxLengthType = 30;

            public const int InterestMinLengthDescription = 20;
            public const int InterestMaxLengthDescription = 400;
        }

        public class Point
        {                             
            public const int PointMinLengthDescription = 20;
            public const int PointMaxLengthDescription = 2000;
        }
    }
}
