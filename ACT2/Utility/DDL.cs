using ACT2.Models;

namespace ACT2.Utility
{
    public static class DDL
    {
       public static List<TblActiveItem>GetActiveItem()
        {
            var _context = new TestContext();
            return _context.TblActiveItems.ToList();
        }
    }
}
