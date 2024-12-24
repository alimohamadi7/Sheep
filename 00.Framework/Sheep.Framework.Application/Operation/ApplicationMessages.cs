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
        public static string NotChangeAble = "  امکان تغییر وجود ندارد";
        public static string SheepParentnotvalid = "   دام مادر در گله در وضعیت   *موجود*  نیست ";
        public static string SheepParentAge = " دام مادر مدت زمان تغییر گروه به میش را طی نکرده است ";
        public static string AddSheepCategoryError = "  در ثبت گروه دامی مشکلی به وجود آمده است ";
        public static string RamIsnotFemale = "  قوچ نمیتواند جنسیت ماده داشته باشد ";
        public static string EveIsnotMale = "  میش نمیتواند جنسیت نر داشته باشد ";
        public static string DuplicateDate = "  این تاریخ قبلا ثبت شده است  ";
        public static string InvalidStartDate = "  تاریخ شروع از پایان بزرگتر است  ";
        public static string StartDateEqualEndDate = " تاریخ شروع و پایان برابر است ";
        public static string DatePeriodNotValid = " بازه تاریخی نامعتبر است ";
        public static string NotFisCalYearValid = " سال مالی وجود دارد  ";
        public static string NotSheepFuondInRaneDate = "بازه تاریخی به هیچ دامی تعلق نمیگیرد  ";
        public static string InvalidSellOrWastedDate = "تاریخ فروش یا تلف شدن نامعتبر است . این تاریخ دام در هزینه های گله محاسبه شده است  ";
        public static string InvalidShopDate = "تاریخ خرید از تولد کوچکتر است";
        public static string InvalidSheepBirthdate = "تاریخ تولد یا خرید بزرگتر از تاریخ روز است";
        public static string SellDatesmallBirthdate = "تاریخ فروش از تولد کوچکتر است";
        public static string WastedDatesmallBirthdate = "تاریخ تلف شدن از تولد کوچکتر است";
        public static string InvalidSellDate = "تاریخ فروش شدن بزرگتر از تاریخ روز است";
        public static string InvalidWastedDate = "تاریخ تلف شدن بزرگتر از تاریخ روز است";
    }
}

