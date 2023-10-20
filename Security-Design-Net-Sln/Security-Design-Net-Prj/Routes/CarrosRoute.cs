namespace Security_Design_Net_Prj.Routes
{
    public static class CarrosRoute
    {
        public static async Task<IResult> GetAll() => TypedResults.Ok();
        public static async Task<IResult> GetById(int id) => TypedResults.Ok();
        public static async Task<IResult> Post() => TypedResults.Ok();
        public static async Task<IResult> Put() => TypedResults.Ok();
    }
}
