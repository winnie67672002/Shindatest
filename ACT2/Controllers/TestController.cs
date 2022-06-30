using ACT2.Models;
using Microsoft.AspNetCore.Mvc;

namespace ACT2.Controllers
{
    public class TestController : Controller
    {
        private readonly TestContext _context;
        public TestController(TestContext context)
        {
            _context = context;
        }
        public IActionResult Index(string queryName ,string queryPhone, string queeryActive)
        {
            
            var signupdata = ( 
                               from  s in _context.TblSignups
                               select new TblSignUpList()
                               {
                                   CId= s.CId,
                                   CName= s.CName,
                                   CEmail= s.CEmail,
                                   CMobile= s.CMobile,
                                   CCreateDt= s.CCreateDt,
                               

                                   cItemName = String.Join(",", (from a in _context.TblActiveItems
                                                               join b in _context.TblSignupItems
                                                               on a.CItemId equals b.CItemId
                                                               where s.CId==b.CSignupId
                                                               select a.CItemName).ToList()
                                                          )
                                                               

                               }).ToList();
                              
           if (!string.IsNullOrEmpty(queryName))
            {
                signupdata= signupdata.Where(s => s.CName.Contains(queryName)).ToList();
            }

            if (!string.IsNullOrEmpty(queryPhone))
            {
                signupdata = signupdata.Where(s => s.CMobile.Contains(queryPhone)).ToList();
            }
            if (!string.IsNullOrEmpty(queeryActive) && queeryActive != "0")
            {
                signupdata = signupdata.Where(s => s.cItemName.Contains(queeryActive)).ToList();
            }

            return View(signupdata);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TblSignupDo tblSignupList)
        {

            if(!tblSignupList.CMobile.StartsWith("09") || tblSignupList.CMobile.Length != 10)
            {
                ViewData["error"]= "電話號碼為十碼且以09開頭";
                return View(tblSignupList);
            }
           

            var TblSignup=new TblSignup();
            TblSignup = new TblSignup()
            {
                CName = tblSignupList.CName,
                CMobile = tblSignupList.CMobile,
                CCreateDt = tblSignupList.CCreateDt,
                CEmail = tblSignupList.CEmail,
               
            };

            _context.TblSignups.Add(TblSignup);
            _context.SaveChanges();

            foreach (var item in tblSignupList.queeryActive)
            {
                var TblSignupItem = new TblSignupItem();

                TblSignupItem.CSignupId = TblSignup.CId;
                TblSignupItem.CItemId = item;
            
                _context.TblSignupItems.Add(TblSignupItem);
                _context.SaveChanges();

            }

            return RedirectToAction(nameof(Index));
        }
    }
}
