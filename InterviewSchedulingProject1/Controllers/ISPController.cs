using InterviewSchedulingProject1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InterviewSchedulingProject1.Controllers
{
    public class ISPController : Controller
    {
        private readonly ISPContext db;
        public ISPController(ISPContext cardDbContext)
        {
            this.db = cardDbContext;
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterUser candidateUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CandidateUser candidateUser1 = new CandidateUser();
                    candidateUser1.username = candidateUser.username;
                    candidateUser1.Password = candidateUser.Password;
                    candidateUser1.Role = "Candidate";
                    db.CandidateUser.Add(candidateUser1);
                    db.SaveChanges();
                    HttpContext.Session.SetString("RegistrationConfirom", "Registered Successfully");
                    return RedirectToAction("Login");


                }
                catch (Exception)
                {

                    throw;
                }

            }

            ViewBag.NotFound = "Please Enter all the details correctly";
            return View(candidateUser);
        }
        public IActionResult Login()
        {
            string RegistrationConfirom;

            ViewBag.register = HttpContext.Session.GetString("RegistrationConfirom");

            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel loginmodel)
        {

            if (ModelState.IsValid)
            {
                var obj = db.CandidateUser.Where(a => a.username == loginmodel.username && a.Password == loginmodel.Password).FirstOrDefault();

                if (obj != null)
                {
                    HttpContext.Session.SetString("UserName", obj.username);
                    HttpContext.Session.SetString("role", obj.Role);
                    HttpContext.Session.SetInt32("id", obj.id);

                    if (obj.Role == "HR")
                    {

                        return RedirectToAction("HrDashboard");
                    }
                    else if (obj.Role == "Candidate")
                    {
                        return RedirectToAction("CandidateDashboard");
                    }
                    else
                    {
                        return RedirectToAction("AdminDashboard");
                    }



                }
            }
            ViewBag.NotFound = "Please Enter The Correct Details Username or Password Not Found";

            return View("Login");
        }


        public IActionResult CandidateDashboard()
        {
            string role = HttpContext.Session.GetString("role");
            if (role == "Candidate")
            {



                int candidateid = ViewBag.Name = HttpContext.Session.GetInt32("id");
                var obj = db.condidateDetails.Where(a => a.Candidateid == candidateid).FirstOrDefault();
                if (obj == null)
                {

                    return RedirectToAction("EditCandidateProfile", candidateid);

                }
                else
                {
                    var obj1 = db.CandidateUser.Where(a => a.id == candidateid).FirstOrDefault();

                    if (obj.graduation == null || obj.tenth == null || obj.twelth == null || obj.skills == null || obj1.DOB == null || obj1.firstname == null || obj1.Gender == null || obj1.lastname == null)
                    {
                        return RedirectToAction("EditCandidateProfile", candidateid);
                    }

                }





                CandidateFullDetails Registerviewmodel = new CandidateFullDetails();




                var siteUser = db.CandidateUser.Where(a => a.id == candidateid).FirstOrDefault();
                var emp = db.condidateDetails.Where(p => p.Candidateid == candidateid).FirstOrDefault();
                //var GetEmployeeDetail_Result = db.GetEmployeeDetail(candidateid);
                CandidateFullDetails fullDetails = new CandidateFullDetails();
                fullDetails.username = siteUser.username;
                fullDetails.Gender = siteUser.Gender;
                fullDetails.firstname = siteUser.firstname;
                fullDetails.lastname = siteUser.lastname;
                fullDetails.Gender = siteUser.Gender;
                fullDetails.phoneno = siteUser.phoneno;
                fullDetails.DOB = siteUser.DOB;
                fullDetails.Role = siteUser.Role;


                if (emp != null)
                {
                    fullDetails.Experince = emp.Experince ?? null;
                    fullDetails.tenth = emp.tenth ?? null;
                    fullDetails.twelth = emp.twelth ?? null;
                    fullDetails.skills = emp.skills ?? null;
                    fullDetails.graduation = emp.graduation ?? null;
                    fullDetails.postgraduation = emp.postgraduation ?? null;
                    fullDetails.Company = emp.Company ?? null;

                }
                if (siteUser.InterviewTiming != null)
                {
                    //string timing = Convert.ToString(siteUser.InterviewTiming);
                    //HttpContext.Session.SetString("InterviewTiming", timing);
                    ViewBag.SelectedTiming = "You Are Selected For Interview";
                }


                return View(fullDetails);



            }

            return View("Login");
        }

        public IActionResult CandidateSeeTimings()
        {
            int candidateid = ViewBag.Name = HttpContext.Session.GetInt32("id");
            var siteUser = db.CandidateUser.Where(a => a.id == candidateid).FirstOrDefault();
            if (siteUser != null)
            {
                var User = db.condidateDetails.Where(a => a.Candidateid == candidateid).FirstOrDefault();

                ViewBag.CompanyName = User.Company;
                return View(siteUser);
            }

            return View("Login");
        }

        public IActionResult EditCandidateProfile()
        {
                int candidateid = ViewBag.Name = HttpContext.Session.GetInt32("id");
            string role = HttpContext.Session.GetString("role");
            if (candidateid != null && role == "Candidate")
            {

                List<Gender> listgen = new List<Gender>();

                listgen.Add(new Gender { GenderId = 1, Genders = "Male" });
                listgen.Add(new Gender { GenderId = 2, Genders = "Female" });
                listgen.Add(new Gender { GenderId = 3, Genders = "Transgender" });

                ViewBag.genderList = new SelectList(listgen, "GenderId", "Genders");


                var siteUser = db.CandidateUser.Where(a => a.id == candidateid).FirstOrDefault();
                var emp = db.condidateDetails.Where(p => p.Candidateid == candidateid).FirstOrDefault();
                //var GetEmployeeDetail_Result = db.GetEmployeeDetail(candidateid);
                CandidateFullDetails fullDetails = new CandidateFullDetails();
                fullDetails.username = siteUser.username;
                fullDetails.Gender = siteUser.Gender;
                fullDetails.firstname = siteUser.firstname;
                fullDetails.lastname = siteUser.lastname;
                fullDetails.Gender = siteUser.Gender;
                fullDetails.phoneno = siteUser.phoneno;
                fullDetails.DOB = siteUser.DOB;
                if (emp != null)
                {
                    fullDetails.Experince = emp.Experince ?? null;
                    fullDetails.tenth = emp.tenth ?? null;
                    fullDetails.twelth = emp.twelth ?? null;
                    fullDetails.skills = emp.skills ?? null;
                    fullDetails.graduation = emp.graduation ?? null;
                    fullDetails.postgraduation = emp.postgraduation ?? null;
                    fullDetails.Company = emp.Company ?? null;

                }

                return View("EditCandidateProfile", fullDetails);



            }

            return View("Login");
        }

        [HttpPost]
        public ActionResult EditCandidateProfile(CandidateFullDetails emp)
        {
            try
            {


                List<Gender> listgen = new List<Gender>();

                listgen.Add(new Gender { GenderId = 1, Genders = "Male" });
                listgen.Add(new Gender { GenderId = 2, Genders = "Female" });
                listgen.Add(new Gender { GenderId = 3, Genders = "Transgender" });

                ViewBag.genderList = new SelectList(listgen, "GenderId", "Genders");


                int candidateid = ViewBag.Name = HttpContext.Session.GetInt32("id");
                string role = HttpContext.Session.GetString("role");

                if (candidateid > 0)
                {
                    CondidateDetails exist = db.condidateDetails.Where(p => p.canditateid == candidateid).FirstOrDefault();
                    if (exist == null)
                    {
                        CandidateUser fullDetaill = db.CandidateUser.Where(a => a.id == candidateid).FirstOrDefault();


                        fullDetaill.Gender = emp.Gender;
                        fullDetaill.firstname = emp.firstname;
                        fullDetaill.lastname = emp.lastname;
                        fullDetaill.Gender = emp.Gender;
                        fullDetaill.phoneno = emp.phoneno;
                        fullDetaill.DOB = emp.DOB;

                        db.SaveChanges();

                        CondidateDetails fullDetails = new CondidateDetails();

                        fullDetails.Experince = emp.Experince;
                        fullDetails.Candidateid = candidateid;
                        fullDetails.tenth = emp.tenth;
                        fullDetails.twelth = emp.twelth;
                        fullDetails.skills = emp.skills;
                        fullDetails.graduation = emp.graduation;
                        fullDetails.postgraduation = emp.postgraduation;
                        fullDetails.Company = emp.Company;

                        db.condidateDetails.Add(fullDetails);
                        db.SaveChanges();

                    }
                    else
                    {
                        CandidateUser fullDetails = db.CandidateUser.Where(a => a.id == candidateid).FirstOrDefault();


                        fullDetails.Gender = emp.Gender;
                        fullDetails.firstname = emp.firstname;
                        fullDetails.lastname = emp.lastname;
                        fullDetails.Gender = emp.Gender;
                        fullDetails.phoneno = emp.phoneno;
                        fullDetails.DOB = emp.DOB;

                        db.SaveChanges();
                        exist.Experince = emp.Experince;

                        exist.tenth = emp.tenth;
                        exist.twelth = emp.twelth;
                        exist.skills = emp.skills;
                        exist.graduation = emp.graduation;
                        exist.postgraduation = emp.postgraduation;
                        exist.Company = emp.Company;

                        db.SaveChanges();
                    }


                    ViewBag.sublit = "Details Submit Successfully";

                    return View();
                }
                return View();
                ViewBag.sublit = "Please Enter The Correct Details ";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IActionResult HrDashboard(string search)
        {

            string role = HttpContext.Session.GetString("role");
            if (role == "HR")
            {
                if (search == null)
                {

                    //var value = db.candidateFullDetails.FromSqlRaw("GetSelectedCandidateList1");
                    //return View(value);
                    var value = db.candidateFullDetails.FromSqlRaw("GetCandidateList1");
                    return View(value);
                }
                else
                {

                    var value = db.candidateFullDetails.FromSqlRaw("SearchCandidate {0}", search);
                    return View(value);
                    //var value = db.candidateFullDetails.FromSqlRaw("[SearchCandidateselcted] {0}", search);
                    //return View(value);
                }

            }
            return View("Login");

        }

        public IActionResult SendMailInterview(string search)
        {

            string role = HttpContext.Session.GetString("role");
            if (role == "HR")
            {
                if (search == null)
                {

                    var value = db.candidateFullDetails.FromSqlRaw("GetSelectedCandidateList1");
                    return View(value);
                }
                else
                {

                    var value = db.candidateFullDetails.FromSqlRaw("[SearchCandidateselcted] {0}", search);
                    return View(value);
                }

            }
            return View("Login");

        }



        public IActionResult AdminDashboard(string search)
        {
            int candidateid = ViewBag.Name = HttpContext.Session.GetInt32("id");
            string role = HttpContext.Session.GetString("role");
            if (candidateid != null && role == "Admin")
            {
                if (search == null)
                {

                    //var value = db.candidateFullDetails.FromSqlRaw("GetCandidateList1");
                    //return View(value);

                    var value = db.candidateFullDetails.FromSqlRaw("GetSelectedCandidateList1");
                    return View(value);
                }
                else
                {
                    var value = db.candidateFullDetails.FromSqlRaw("[SearchCandidateselcted] {0}", search);
                    return View(value);
                    //var value = db.candidateFullDetails.FromSqlRaw("SearchCandidate {0}", search);
                    //return View(value);
                }
            }
            return View("Login");

        }


        public IActionResult AdminEditCandidate(int id)
        {
            int candidateid = ViewBag.Name = HttpContext.Session.GetInt32("id");
            string role = HttpContext.Session.GetString("role");
            if (candidateid != null && (role == "Admin" || role == "HR"))
            {
                if (id != null)
                {



                    var siteUser = db.CandidateUser.Where(a => a.id == id).FirstOrDefault();
                    var emp = db.condidateDetails.Where(p => p.Candidateid == id).FirstOrDefault();

                    CandidateFullDetails fullDetails = new CandidateFullDetails();
                    fullDetails.username = siteUser.username;
                    fullDetails.Gender = siteUser.Gender;
                    fullDetails.firstname = siteUser.firstname;
                    fullDetails.lastname = siteUser.lastname;
                    fullDetails.Gender = siteUser.Gender;
                    fullDetails.phoneno = siteUser.phoneno;
                    fullDetails.DOB = siteUser.DOB;
                    fullDetails.Selected = siteUser.selected;
                    if (emp != null)
                    {
                        fullDetails.Experince = emp.Experince;
                        fullDetails.tenth = emp.tenth;
                        fullDetails.twelth = emp.twelth;
                        fullDetails.skills = emp.skills;
                        fullDetails.graduation = emp.graduation;
                        fullDetails.postgraduation = emp.postgraduation;
                        fullDetails.Company = emp.Company;

                    }

                    return View("AdminEditCandidate", fullDetails);



                }
            }
            return View("Login");

        }


        [HttpPost]
        public ActionResult AdminEditCandidate(CandidateFullDetails emp)
        {
            int candidateid = ViewBag.Name = HttpContext.Session.GetInt32("id");
            string role = HttpContext.Session.GetString("role");
            if (candidateid != null && (role == "Admin" || role == "HR"))
            {
                try
                {

                    if (candidateid > 0)
                    {
                        CondidateDetails exist = db.condidateDetails.Where(p => p.canditateid == emp.id).FirstOrDefault();
                        if (exist == null)
                        {
                            CandidateUser fullDetaill = db.CandidateUser.Where(a => a.id == emp.id).FirstOrDefault();


                            fullDetaill.Gender = emp.Gender;
                            fullDetaill.firstname = emp.firstname;
                            fullDetaill.lastname = emp.lastname;
                            fullDetaill.Gender = emp.Gender;
                            fullDetaill.phoneno = emp.phoneno;
                            fullDetaill.DOB = emp.DOB;
                            fullDetaill.selected = emp.Selected;

                            db.SaveChanges();

                            CondidateDetails fullDetails = new CondidateDetails();

                            fullDetails.Experince = emp.Experince;
                            fullDetails.Candidateid = candidateid;
                            fullDetails.tenth = emp.tenth;
                            fullDetails.twelth = emp.twelth;
                            fullDetails.skills = emp.skills;
                            fullDetails.graduation = emp.graduation;
                            fullDetails.postgraduation = emp.postgraduation;
                            fullDetails.Company = emp.Company;

                            db.condidateDetails.Add(fullDetails);
                            db.SaveChanges();

                        }
                        else
                        {
                            CandidateUser fullDetails = db.CandidateUser.Where(a => a.id == emp.id).FirstOrDefault();


                            fullDetails.Gender = emp.Gender;
                            fullDetails.firstname = emp.firstname;
                            fullDetails.lastname = emp.lastname;
                            fullDetails.Gender = emp.Gender;
                            fullDetails.phoneno = emp.phoneno;
                            fullDetails.DOB = emp.DOB;
                            fullDetails.selected = emp.Selected;
                            db.SaveChanges();
                            exist.Experince = emp.Experince;

                            exist.tenth = emp.tenth;
                            exist.twelth = emp.twelth;
                            exist.skills = emp.skills;
                            exist.graduation = emp.graduation;
                            exist.postgraduation = emp.postgraduation;
                            exist.Company = emp.Company;

                            db.SaveChanges();
                        }


                        ViewBag.sublit = "Details Edit Successfully";

                        return RedirectToAction("AdminDashboard");
                    }
                    return View();
                    ViewBag.sublit = "Please Enter The Correct Details ";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View("Login");
        }

        [HttpPost]
        public IActionResult AdminDeletCandidate(int cadid)
        {
            int candidateid = ViewBag.Name = HttpContext.Session.GetInt32("id");
            string role = HttpContext.Session.GetString("role");
            if (candidateid != null && role == "Admin")
            {
                CandidateUser role_Table11 = db.CandidateUser.Where(x => x.id == cadid).FirstOrDefault();
                if (role_Table11 != null)
                {
                    CondidateDetails condidateDetails = db.condidateDetails.Where(x => x.Candidateid == cadid).FirstOrDefault();
                    if (condidateDetails != null)
                    {
                        db.condidateDetails.Remove(condidateDetails);
                        db.CandidateUser.Remove(role_Table11);
                        db.SaveChanges();
                    }


                    ViewBag.sublit = "Deleted Submit Successfully";

                    return RedirectToAction("AdminDashboard");
                }


            }
            return View("Login");

        }


        public IActionResult HrEditCandidate(int id)
        {
            int candidateid = ViewBag.Name = HttpContext.Session.GetInt32("id");
            string role = HttpContext.Session.GetString("role");
            if (candidateid != null && (role == "HR"))
            {
                if (id != null)
                {



                    var siteUser = db.CandidateUser.Where(a => a.id == id).FirstOrDefault();
                    var emp = db.condidateDetails.Where(p => p.Candidateid == id).FirstOrDefault();

                    CandidateFullDetails fullDetails = new CandidateFullDetails();
                    fullDetails.username = siteUser.username;
                    fullDetails.Gender = siteUser.Gender;
                    fullDetails.firstname = siteUser.firstname;
                    fullDetails.lastname = siteUser.lastname;
                    fullDetails.Gender = siteUser.Gender;
                    fullDetails.phoneno = siteUser.phoneno;
                    fullDetails.DOB = siteUser.DOB;
                    fullDetails.Selected = siteUser.selected;
                    if (emp != null)
                    {
                        fullDetails.Experince = emp.Experince;
                        fullDetails.tenth = emp.tenth;
                        fullDetails.twelth = emp.twelth;
                        fullDetails.skills = emp.skills;
                        fullDetails.graduation = emp.graduation;
                        fullDetails.postgraduation = emp.postgraduation;
                        fullDetails.Company = emp.Company;

                    }

                    return View("HrEditCandidate", fullDetails);



                }
            }
            return View("Login");

        }


        [HttpPost]
        public ActionResult HrEditCandidate(CandidateFullDetails emp)
        {
            int candidateid = ViewBag.Name = HttpContext.Session.GetInt32("id");
            string role = HttpContext.Session.GetString("role");
            if (candidateid != null && (role == "HR"))
            {
                try
                {

                    if (candidateid > 0)
                    {
                        CondidateDetails exist = db.condidateDetails.Where(p => p.canditateid == emp.id).FirstOrDefault();
                        if (exist == null)
                        {
                            CandidateUser fullDetaill = db.CandidateUser.Where(a => a.id == emp.id).FirstOrDefault();


                            fullDetaill.Gender = emp.Gender;
                            fullDetaill.firstname = emp.firstname;
                            fullDetaill.lastname = emp.lastname;
                            fullDetaill.Gender = emp.Gender;
                            fullDetaill.phoneno = emp.phoneno;
                            fullDetaill.DOB = emp.DOB;
                            fullDetaill.selected = emp.Selected;

                            db.SaveChanges();

                            CondidateDetails fullDetails = new CondidateDetails();

                            fullDetails.Experince = emp.Experince;
                            fullDetails.Candidateid = candidateid;
                            fullDetails.tenth = emp.tenth;
                            fullDetails.twelth = emp.twelth;
                            fullDetails.skills = emp.skills;
                            fullDetails.graduation = emp.graduation;
                            fullDetails.postgraduation = emp.postgraduation;
                            fullDetails.Company = emp.Company;

                            db.condidateDetails.Add(fullDetails);
                            db.SaveChanges();

                        }
                        else
                        {
                            CandidateUser fullDetails = db.CandidateUser.Where(a => a.id == emp.id).FirstOrDefault();

                            CondidateDetails existss = db.condidateDetails.Where(p => p.canditateid == emp.id).FirstOrDefault();
                            existss.Experince = emp.Experince;
                            existss.tenth = emp.tenth;
                            existss.twelth = emp.twelth;
                            existss.skills = emp.skills;
                            existss.graduation = emp.graduation;
                            existss.postgraduation = emp.postgraduation;
                            existss.Company = emp.Company;
                            db.SaveChanges();

                            fullDetails.Gender = emp.Gender;
                            fullDetails.firstname = emp.firstname;
                            fullDetails.lastname = emp.lastname;
                            fullDetails.Gender = emp.Gender;
                            fullDetails.phoneno = emp.phoneno;
                            fullDetails.DOB = emp.DOB;
                            fullDetails.selected = emp.Selected;
                            db.SaveChanges();

                          
                          
                        }


                        ViewBag.sublit = "Details Edit Successfully";

                        return RedirectToAction("HrEditCandidate");
                    }
                    return View();
                    ViewBag.sublit = "Please Enter The Correct Details ";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View("Login");
        }



        public ActionResult SetInterviewTiming(int id)
        {

            string role = HttpContext.Session.GetString("role");
            if (role == "HR")
            {
                if (id != null)
                {
                    SaveInterviewTimings setInterviewTiming = new SaveInterviewTimings();
                    setInterviewTiming.Candidateid = id;


                    return View(setInterviewTiming);
                }
            }
            return View("Login");

        }

        [HttpPost]
        public ActionResult SetInterviewTiming(SaveInterviewTimings setInterviewTiming)
        {
            string role = HttpContext.Session.GetString("role");
            if (role == "HR")
            {
                if (setInterviewTiming != null)
                {
                    CandidateUser Detail = db.CandidateUser.Where(x => x.id == setInterviewTiming.Candidateid).FirstOrDefault();
                    Detail.InterviewTiming = setInterviewTiming.InterviewTiming;
                    Detail.selected = setInterviewTiming.selected;

                    db.SaveChanges();


                    CondidateDetails exist = db.condidateDetails.Where(p => p.Candidateid == setInterviewTiming.Candidateid).FirstOrDefault();
                    exist.Company = setInterviewTiming.Company;



                    db.SaveChanges();
                    ViewBag.success = "Interview Timing Has Been Set ";
                    return View();
                }
            }
            return View("Login");
        }
       

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "ISP");
        }


        [HttpPost]
        public IActionResult Login2(string data)
        {

            //if (ModelState.IsValid)
            //{
            //    var obj = db.CandidateUser.Where(a => a.username == loginmodel.username && a.Password == loginmodel.Password).FirstOrDefault();

            //    if (obj != null)
            //    {
            //        HttpContext.Session.SetString("UserName", obj.username);
            //        HttpContext.Session.SetString("role", obj.Role);
            //        HttpContext.Session.SetInt32("id", obj.id);

            //        if (obj.Role == "HR")
            //        {

            //            return RedirectToAction("HrDashboard");
            //        }
            //        else if (obj.Role == "Candidate")
            //        {
            //            return RedirectToAction("CandidateDashboard");
            //        }
            //        else
            //        {
            //            return RedirectToAction("AdminDashboard");
            //        }



            //    }
            //}
            //ViewBag.NotFound = "Please Enter The Correct Details Username or Password Not Found";

            return View("Login");
        }


    }
}

public class Gender
{
    public int GenderId { get; set; }
    public string Genders { get; set; }
}
