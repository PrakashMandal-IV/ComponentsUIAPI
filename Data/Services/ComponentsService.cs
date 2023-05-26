namespace ComponentsUIAPI.Data.Services
{
    public class ComponentsService
    {
        private QueryExecutionService _eq;
        private readonly Tools _tools;
        public ComponentsService(Tools tools, QueryExecutionService queryExecution)
        {
            _eq = queryExecution;
            _tools = tools;
        }



        public string GetComponentCategoryList()
        {
            string qry = "SELECT * FROM tblComponentsCategory ";
            return _tools.DataTableSystemTextJson(_eq.DataTable(qry));
        }
    }
}
