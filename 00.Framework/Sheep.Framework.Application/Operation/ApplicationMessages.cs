namespace Sheep.Framework.Application.Operation
{
    public class ApplicationMessages
    {
        public const string DuplicatedRecord = "امکان ثبت رکورد تکراری وجود ندارد. لطفا مجدد تلاش بفرمایید.";
        public const string RecordNotFound = "رکورد با اطلاعات درخواست شده یافت نشد. لطفا مجدد تلاش بفرمایید.";
        public static string PasswordsNotMatch = "پسورد و تکرار آن با هم مطابقت ندارند";
        public static string WrongUserPass = "نام کاربری یا کلمه رمز اشتباه است";
        public static string NotSheepFound = "! دام مادر یافت نشد ";
        public static string SheepMale = " شماره دام مادر با جنسیت نر ثبت شده است ";
        public static string SheepIsParentNotMale = " جنسیت این شماره دام به علت داشتن بره قابل تغییر نیست ";
        public static string NotSameNumber = " شماره دام و شماره دام مادر مشابه است ";
        public static string SheepIsParentChangesheepNumber = "  شماره دام به علت داشتن بره قابل تغییر نیست ";
        public static string SheepParentIdChangeTosheepNumber = "  امکان تغییر شماره دام مادر با شماره دام نیست ";

    }
}

