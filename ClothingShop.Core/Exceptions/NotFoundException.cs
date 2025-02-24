namespace ClothingShop.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        //public NotFoundException(ErrorCode errorCode) : base(errorCode.AsString(EnumFormat.Description))
        //{

        //}
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
