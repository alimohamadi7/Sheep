using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Framework.Application.Validation
{
    public class ValidationMessages
    {
        public const string IsRequired = "لطفا {0} را وارد کنید";
        public const string MaxFileSize = "فایل حجیم تر از حد مجاز است";
        public const string InvalidFileFormat = "فرمت فایل مجاز نیست";
        public const string MaxLenght = "{0} نمی تواند بیشتر از {1} کاراکتر باشد";
        public const string Number = "مقدار وارد شده باید عدد باشد";
        public const string InvalidUsername = "نام کاربری معتبر نمیباشد-از حروف انگلیسی استفاده کنید";
        public const string InvalidPhone = "شماره تلفن را بدرستی وارد کنید";
        public const string InvalidPhoto = "لطفا یک عکس انتخاب نمایید";
        public const string InvalidVideo = "انتخاب نمایید Mp4 لطفا یک ویدئو با فرمت ";
        public const string InvalidFile = "انتخاب نمایید pdf  لطفا یک فایل   ";
        public const string InvalidNationalcode = "لطفا کد ملی را بدرستی وارد کنید";
        public const string Invalidpersonalnumber = "لطفا شماره پرسنلی را بدرستی وارد کنید";
        public const string Invalidnumber = "لطفا عدد وارد کنید";
    }
}
