using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModels;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeListViewModel empListModel = new EmployeeListViewModel();
            //实例化员工信息业务层
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            //员工原始数据列表，获取来自业务层类的数据
            var listEmp = empBL.GetEmployeeList();
            //获取将处理过的数据列表
            empListModel.EmployeeViewList =getEmpVmList(listEmp);
            // 获取问候语
            empListModel.Greeting = getGreeting();
            //获取用户名
            empListModel.UserName = getUserName();
            //将数据送往视图
            return View(empListModel);
        }
        //Add
        public ActionResult AddNew() {
            return View("CreateEmployee");
        }
        //Add
        public ActionResult Save(Employee emp)
        {

            EmployeeBusinessLayer empL = new EmployeeBusinessLayer();
            empL.Add(emp);

            return new RedirectResult("/employee/index");
        }
        //Delete
        public ActionResult DeleteNew(int id)
        {

            
            EmployeeBusinessLayer empL = new EmployeeBusinessLayer();     
            empL.Delete(id);
            return new RedirectResult("/employee/index");
        }
        //Update
        public ActionResult UpdateNew(int id)
        {
            EmployeeBusinessLayer empL = new EmployeeBusinessLayer();
            Employee emp = empL.Query(id);
            return View(emp);
            // return View("UpdateEmployee");
        }
        //Update
        public ActionResult Update(Employee emp)
        {
           // ViewBag.id = id;         
           EmployeeBusinessLayer empL = new EmployeeBusinessLayer();
                    
            empL.Update(emp);
            return new RedirectResult("/employee/index");
        }
        //Select 根据Name进行模糊查找 显示查找到到Name和工资
        public ActionResult Select(string name)
        {
            EmployeeBusinessLayer empL = new EmployeeBusinessLayer();
            var query = empL.Select(name);

            EmployeeListViewModel empListModel = new EmployeeListViewModel();
            //获取将处理过的数据列表
            empListModel.EmployeeViewList = getEmpVmList(query.ToList());
            // 获取问候语
            empListModel.Greeting = getGreeting();
            //获取用户名
            empListModel.UserName = getUserName();
            return View("index",empListModel);
        }
        [NonAction]
        List<EmployeeViewModel> getEmpVmList(List<Employee>listEmp)
        {
            //实例化员工信息业务层
            //EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            //员工原始数据列表，获取来自业务层类的数据
            //var listEmp = empBL.GetEmployeeList();
            //员工原始数据加工后的视图数据列表，当前状态是空的
            var listEmpVm = new List<EmployeeViewModel>();

            //通过循环遍历员工原始数据数组，将数据一个一个的转换，并加入listEmpVm
            foreach (var item in listEmp)
            {
                EmployeeViewModel empVmObj = new EmployeeViewModel();
                empVmObj.EmployeeName = item.Name;
                empVmObj.EmployeeId = item.EmployeeID;
                empVmObj.EmployeeSalary = item.Salary.ToString("C");
                if (item.Salary > 10000)
                {
                    empVmObj.EmployeeGrade = "土豪";
                }
                else
                {
                    empVmObj.EmployeeGrade = "平民";
                }

                listEmpVm.Add(empVmObj);
            }

            return listEmpVm;

        }


        [NonAction]
        string getGreeting()
        {
            string greeting;
            //获取当前时间
            DateTime dt = DateTime.Now;
            //获取当前小时数
            int hour = dt.Hour;
            //根据小时数判断需要返回哪个视图，<12 返回myview 否则返回 yourview
            if (hour < 12)
            {
                greeting = "早上好";
            }
            else
            {
                greeting = "下午好";
            }
            return greeting;
        }


        [NonAction]
        string getUserName()
        {
            return "Admin";
        }
    }
}