namespace blog.Mappers
{
    public static class ToEnumMapper
    {
        public static Entities.StateEnum ToEnumMappers(this Models.StateEnum? state)
            => state switch
            {
                Models.StateEnum.Pending => Entities.StateEnum.Pending,
                Models.StateEnum.Rejected => Entities.StateEnum.Rejected,
                _ => Entities.StateEnum.Approved
            };
    }
}