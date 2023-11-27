using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using O_T_M_POPUP_WITHCASCADE_SP.Models.context;
using O_T_M_POPUP_WITHCASCADE_SP.Models;
using Microsoft.EntityFrameworkCore;
using O_T_M_POPUP_WITHCASCADE_SP.HelperFolder;

namespace O_T_M_POPUP_WITHCASCADE_SP.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MainDbContext _dbContext;
        public EmployeeController(MainDbContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index()
        {
            var emp =  _dbContext.Employees.Include(d => d.department).Include(d => d.Country).Include(d => d.State).Include(c => c.City).ToList();
            return View(emp);
        }

        /*  public IActionResult AddOrEdit(int id)
          {
              if (id == 0)
              {
                  // Code for creating a new employee
                  ViewBag.Countries = _dbContext.Countries.ToList();
                  ViewBag.States = _dbContext.States.ToList();
                  ViewBag.Cities = _dbContext.States.ToList();

                  ViewData["CountryId"] = new SelectList(_dbContext.Countries, "CountryId", "CountryName");
                  ViewData["StateId"] = new SelectList(_dbContext.States, "StateId", "StateName");
                  ViewData["CityId"] = new SelectList(_dbContext.Cities, "CityId", "CityName");
                  ViewData["Dept_Id"] = new SelectList(_dbContext.Departments, "Dept_ID", "Dep_Name");

                  return View(new Employee());
              }
              else
              {
                  // Code for editing an existing employee
                  var emp = _dbContext.Employees.Find(id);
                  if (emp == null)
                  {
                      return NotFound();
                  }
                  ViewBag.Countries = _dbContext.Countries.ToList();
                  ViewBag.States = _dbContext.States.ToList();
                  ViewBag.Cities = _dbContext.States.ToList();
                  ViewData["CountryId"] = new SelectList(_dbContext.Countries, "CountryId", "CountryName");
                  ViewData["CityId"] = new SelectList(_dbContext.Cities, "CityId", "CityName");
                  ViewData["StateId"] = new SelectList(_dbContext.States, "StateId", "StateName");
                  ViewData["Dept_Id"] = new SelectList(_dbContext.Departments, "Dept_ID", "Dep_Name");

                  return View(emp);
              }
          }*/
        public IActionResult AddOrEdit(int id = 0)
        {
            
            if (id == 0)
            {
                // Code for creating a new employee
                ViewBag.Countries = _dbContext.Countries.ToList();
                ViewBag.States = _dbContext.States.ToList();
               

                ViewData["CountryId"] = new SelectList(_dbContext.Countries, "CountryId", "CountryName");
                ViewData["StateId"] = new SelectList(_dbContext.States, "StateId", "StateName");
                ViewData["CityId"] = new SelectList(_dbContext.Cities, "CityId", "CityName");
                ViewData["Dep_ID"] = new SelectList(_dbContext.Departments, "Dep_ID", "Dep_Name");
                return View(new Employee());
            }
            else
            {
                // Code for editing an existing employee
                var emp = _dbContext.Employees.Find(id);
                if (emp == null)
                {
                    return NotFound();
                }
                ViewBag.Countries = _dbContext.Countries.ToList();
                ViewBag.States = _dbContext.States.ToList();
                

                ViewData["CountryId"] = new SelectList(_dbContext.Countries, "CountryId", "CountryName");
                ViewData["StateId"] = new SelectList(_dbContext.States, "StateId", "StateName");
                ViewData["CityId"] = new SelectList(_dbContext.Cities, "CityId", "CityName");
                ViewData["Dep_ID"] = new SelectList(_dbContext.Departments, "Dep_ID", "Dep_Name");
                return View(emp);
            }
        }

        /* [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> AddOrEdit(int id, [Bind("Emp_ID", "Emp_name", "Sallary", "Dept_ID", "Dep_Name", "CountryId", "CountryName", "StateId", "StateName", "CityId", "CityName")] Employee employee)
         {
             if (id == 0)
             {
                 ViewData["CountryId"] = new SelectList(_dbContext.Countries, "CountryId", "CountryName", employee.CountryId);
                 ViewData["StateId"] = new SelectList(_dbContext.States, "StateId", "StateName", employee.StateId);
                 ViewData["CityId"] = new SelectList(_dbContext.Cities, "CityId", "CityName", employee.CityId);
                 ViewData["Dep_ID"] = new SelectList(_dbContext.Departments, "Dep_ID", "Dep_Name", employee.Dep_ID);
                 _dbContext.Employees.Add(employee);
                 await _dbContext.SaveChangesAsync();
                 return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _dbContext.Employees.ToList()) });
             }
             else
             {
                 var result = await _dbContext.InsertOrUpdateEmployee(employee.Emp_ID, employee.Emp_name, employee.Gender, employee.Sallary, employee.CountryId, employee.CityId, employee.StateId, employee.Dep_ID);

                 var existingEmployee = await _dbContext.Employees.FindAsync(id);
                 if (existingEmployee != null)
                 {
                     existingEmployee.Emp_name = employee.Emp_name;
                     existingEmployee.Gender = employee.Gender;
                     existingEmployee.Sallary = employee.Sallary;
                     existingEmployee.Dep_ID = employee.Dep_ID;
                     existingEmployee.CountryId = employee.CountryId;
                     existingEmployee.StateId = employee.StateId;
                     existingEmployee.CityId = employee.CityId;
                     _dbContext.Update(existingEmployee);
                     await _dbContext.SaveChangesAsync();
                 }
                 else
                 {
                     return NotFound();
                 }
             }

             var updatedEmployees = await _dbContext.Employees
                 .Include(d => d.department)
                 .Include(d => d.Country)
                 .Include(d => d.State)
                 .Include(c => c.City)
                 .ToListAsync();

             var updatedHtml = Helper.RenderRazorViewToString(this, "_ViewAll", updatedEmployees);

             return Json(new { isValid = true, html = updatedHtml });
         }*/

       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Emp_ID", "Emp_name", "Sallary", "Dept_ID", "Dep_Name", "CountryId", "CountryName", "StateId", "StateName", "CityId", "CityName")] Employee employee)
        {
            if (id == 0)
            {

                await _dbContext.InsertOrUpdateEmployee(employee.Emp_ID, employee.Emp_name, employee.Gender, employee.Sallary, employee.CountryId, employee.CityId, employee.StateId, employee.Dep_ID);
            }
            else
            {

                var existingEmployee = await _dbContext.Employees.FindAsync(id);
                if (existingEmployee == null)
                {
                    return NotFound();
                }

                existingEmployee.Emp_name = employee.Emp_name;
                existingEmployee.Gender = employee.Gender;
                existingEmployee.Sallary = employee.Sallary;
                existingEmployee.Dep_ID = employee.Dep_ID;
                existingEmployee.CountryId = employee.CountryId;
                existingEmployee.StateId = employee.StateId;
                existingEmployee.CityId = employee.CityId;

                _dbContext.Update(existingEmployee);
            }

            await _dbContext.SaveChangesAsync();

            var updatedEmployees = await _dbContext.Employees
                .Include(d => d.department)
                .Include(d => d.Country)
                .Include(d => d.State)
                .Include(c => c.City)
                .ToListAsync();

            var updatedHtml = Helper.RenderRazorViewToString(this, "_ViewAll", updatedEmployees);

            return Json(new { isValid = true, html = updatedHtml });
        }
*/
        /* [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> AddOrEdit(int id, [Bind("Emp_ID", "Emp_name", "Sallary", "Dept_ID", "Dep_Name", "CountryId", "CountryName", "StateId", "StateName", "CityId", "CityName")] Employee employee)
         {


             if (id == 0)
             {
                 // Creating a new employee
                 var newEmployee = new Employee
                 {
                     Emp_name = employee.Emp_name,
                     Gender = employee.Gender,
                     Sallary = employee.Sallary,
                     Dep_ID = employee.Dep_ID,
                     CountryId = employee.CountryId,
                     StateId = employee.StateId,
                     CityId = employee.CityId
                     // Set other properties as needed
                 };

                 _dbContext.Employees.Add(newEmployee);
             }
             else
             {
                 // Updating an existing employee
                 var existingEmployee = await _dbContext.Employees.FindAsync(id);
                 if (existingEmployee == null)
                 {
                     return NotFound();
                 }

                 existingEmployee.Emp_name = employee.Emp_name;
                 existingEmployee.Gender = employee.Gender;
                 existingEmployee.Sallary = employee.Sallary;
                 existingEmployee.Dep_ID = employee.Dep_ID;
                 existingEmployee.CountryId = employee.CountryId;
                 existingEmployee.StateId = employee.StateId;
                 existingEmployee.CityId = employee.CityId;

                 _dbContext.Update(existingEmployee);
             }

             await _dbContext.SaveChangesAsync();

             var updatedEmployees = await _dbContext.Employees
                 .Include(d => d.department)
                 .Include(d => d.Country)
                 .Include(d => d.State)
                 .Include(c => c.City)
                 .ToListAsync();

             var updatedHtml = Helper.RenderRazorViewToString(this, "_ViewAll", updatedEmployees);

             return Json(new { isValid = true, html = updatedHtml });
         }
 *//*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Emp_ID", "Emp_name", "Gender", "Sallary", "Dep_ID", "CountryId", "StateId", "CityId")] Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == 0)
                    {
                        // Creating a new employee
                        var newEmployee = new Employee
                        {
                            Emp_name = employee.Emp_name,
                            Gender = employee.Gender,
                            Sallary = employee.Sallary,
                            Dep_ID = employee.Dep_ID,
                            CountryId = employee.CountryId,
                            StateId = employee.StateId,
                            CityId = employee.CityId
                            // Set other properties as needed
                        };

                        _dbContext.Employees.Add(newEmployee);
                    }
                    else
                    {
                        // Updating an existing employee
                        var existingEmployee = await _dbContext.Employees.FindAsync(id);
                        if (existingEmployee == null)
                        {
                            return NotFound();
                        }

                        existingEmployee.Emp_name = employee.Emp_name;
                        existingEmployee.Gender = employee.Gender;
                        existingEmployee.Sallary = employee.Sallary;
                        existingEmployee.Dep_ID = employee.Dep_ID;
                        existingEmployee.CountryId = employee.CountryId;
                        existingEmployee.StateId = employee.StateId;
                        existingEmployee.CityId = employee.CityId;

                        _dbContext.Update(existingEmployee);
                    }

                    await _dbContext.SaveChangesAsync();

                    var updatedEmployees = await _dbContext.Employees
                        .Include(d => d.department)
                        .Include(d => d.Country)
                        .Include(d => d.State)
                        .Include(c => c.City)
                        .ToListAsync();

                    var updatedHtml = Helper.RenderRazorViewToString(this, "_ViewAll", updatedEmployees);

                    return Json(new { isValid = true, html = updatedHtml });
                }

                // ModelState is not valid, return the view with errors
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return Json(new { isValid = false, errors = errors });
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }*/

        [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> AddOrEdit(int id, [Bind("Emp_ID", "Emp_name", "Gender", "Sallary", "Dep_ID", "CountryId", "StateId", "CityId")] Employee employee)
          {
              if (id == 0)
              {
                  ViewData["StateId"] = new SelectList(_dbContext.States, "StateId", "StateName", employee.StateId);
                  ViewData["CityId"] = new SelectList(_dbContext.Cities, "CityId", "CityName", employee.CityId);

                  ViewData["Dep_ID"] = new SelectList(_dbContext.Departments, "Dep_ID", "Dep_Name", employee.Dep_ID);
                  var result = await _dbContext.InsertOrUpdateEmployee(employee.Emp_ID, employee.Emp_name, employee.Gender, employee.Sallary, employee.CountryId, employee.CityId, employee.StateId, employee.Dep_ID);
                  if(result != null)
                  {
                      await _dbContext.SaveChangesAsync();
                  }
                  //_dbContext.Employees.Add(employee);


              }
              else
              {
                  try
                  {
                      ViewData["StateId"] = new SelectList(_dbContext.States, "StateId", "StateName", employee.StateId);
                      ViewData["CityId"] = new SelectList(_dbContext.Cities, "CityId", "CityName", employee.CityId);

                      ViewData["Dep_ID"] = new SelectList(_dbContext.Departments, "Dep_ID", "Dep_Name", employee.Dep_ID);
                      var result = await _dbContext.InsertOrUpdateEmployee(employee.Emp_ID, employee.Emp_name, employee.Gender, employee.Sallary, employee.CountryId, employee.CityId, employee.StateId, employee.Dep_ID);
                      if (result != null)
                      {
                          await _dbContext.SaveChangesAsync();
                      }
                      // _dbContext.Update(employee);
                      //await _dbContext.SaveChangesAsync();


                  }
                  catch (DbUpdateConcurrencyException)
                  {
                      if (!ExployeeExist(employee.Emp_ID))
                      {
                          return NotFound();
                      }
                      else
                      {
                          throw;
                      }

                  }

                  return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _dbContext.Employees.ToList()) });
              }

              return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", employee) });
          }

          private bool ExployeeExist(int emp_Id)
          {
              throw new NotImplementedException();
          }
  

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var emp = await _dbContext.Employees.Include(d => d.department).FirstOrDefaultAsync(x => x.Emp_ID == id);
            _dbContext.Employees.Remove(emp);
            await _dbContext.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", emp) });


        }
        [HttpGet]
        public JsonResult GetCitiesByState(int stateId)
        {
            var cities = _dbContext.Cities.Where(c => c.StateId == stateId).ToList();
            return Json(cities);
        }

        [HttpGet]
        public JsonResult GetStatesByCountry(int countryId)
        {
            var states = _dbContext.States.Where(s => s.CountryId == countryId).ToList();
            return Json(states);
        }
    }
}



 