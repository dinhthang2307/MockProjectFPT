namespace VLMS.Database.Infracstructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private VLMSDataEntities dbContext;

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
        public VLMSDataEntities Init()
        {
            return dbContext ?? (dbContext = new VLMSDataEntities());
        }
    }
}
