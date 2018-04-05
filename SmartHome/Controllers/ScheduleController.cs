using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using SmartHome.DAL;
using SmartHome.DAL.Mappers;
using SmartHome.Models;
using SmartHome.Templates;

namespace SmartHome.Controllers
{
    public class ScheduleController : Controller
    {
        /*internal DataGateway<Schedule> dataGateway;
        internal DataGateway<Device> dataGateway2;

        public ScheduleController(SmartHomeDbContext context)
        {
            dataGateway = new ScheduleGateway(context);
            dataGateway2 = new DeviceGateway(context);
        }*/

        private static IScheduleMapper _ScheduleMapper = new ScheduleMapper();
        private static IHouseholdMapper _HouseholdMapper = new HouseholdMapper();
        private static IDeviceMapper _DeviceMapper = new DeviceMapper();

        // GET: Scheduler
        public ActionResult Index()
        {
            return View(_ScheduleMapper.SelectAll());
        }

        // GET: Scheduler
        public ActionResult Index1()
        {
            return View(_ScheduleMapper.SelectAll());
        }

        // GET: Scheduler/Details/5
        public ActionResult Details(ObjectId id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Schedule schedule = _ScheduleMapper.SelectById(id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Tours/Confirm
        public ActionResult Confirm(Schedule schedule)
        {
            ViewData["Device"] = ADevice();
            //return View("Confirm", schedule);
            return View();
        }

        [HttpGet]
        public ActionResult SelectDay(string day)
        {
            TempData["selectedDay"] = day;
            return RedirectToAction("Index", "Device");
        }

        // GET: Scheduler/Create
        /*[HttpGet]
        public ActionResult Create(int id, string deviceName)
        {

            @ViewBag.dID = id;
            @ViewBag.dName = deviceName;
            ViewBag.dDay = TempData["selectedDay"];

            return View();
        }*/
        
        public ActionResult Create()
        {
            //ViewBag.dDay = TempData["selectedDay"];

            //// store the device object to a view data
            ViewData["Device"] = ADevice();
            //ViewBag.abc = device;

            //// store the serialized device object to a view data
            //ViewData["DeviceSerialize"] = Serialize(device);

            return View();
        }



        // POST: Scheduler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Schedule schedule, string automateSettings)
        //public ActionResult Create(IFormCollection form)
        {
            //[Bind("ScheduleId,deviceId,startTime,endTime,applyToEveryWeek,dayOfWeek,statusWhenOn")]

            if(automateSettings == "check")
            {
                /*AbstractScheduleEngine scheduleEngine;

                Device aDevice = ADevice();
                if(aDevice.Type.Equals("Fan"))
                {
                    scheduleEngine = new FanScheduleEngineTemplate();
                    int suggestFanSpeed = scheduleEngine.sensorRecommendedValue(schedule.StartTime);
                    schedule.StatusWhenOn = suggestFanSpeed;
                }
                else if (aDevice.Type.Equals("Aircon"))
                {
                    scheduleEngine = new AirconScheduleEngineTemplate();
                    int suggestAirconSpeed = scheduleEngine.sensorRecommendedValue(schedule.StartTime);
                    schedule.StatusWhenOn = suggestAirconSpeed;
                }
                else if (aDevice.Type.Equals("Light"))
                {
                    scheduleEngine = new LightScheduleEngineTemplate();
                    int suggestLightSpeed = scheduleEngine.sensorRecommendedValue(schedule.StartTime);
                    schedule.StatusWhenOn = suggestLightSpeed;
                }*/

                    
            }



            //[Bind("ScheduleId,deviceId,startTime,endTime,applyToEveryWeek,dayOfWeek,statusWhenOn")] 


            /*TimeSpan startTime = Convert.ToDateTime(form["startTime"].ToString());
            TimeSpan endTime = Convert.ToDateTime(form["endTime"].ToString());
            bool applyToEveryWeek = Convert.ToBoolean(form["applyToEveryWeek"].ToString());
            string dayOfWeek = form["dayOfWeek"].ToString();
            int deviceId = Convert.ToInt32(form["deviceId"].ToString());
            Device device = Deserialize<Device>(form["device"].ToString());

            Schedule schedule = new Schedule();
            schedule.startTime = startTime;
            schedule.endTime = endTime;
            schedule.applyToEveryWeek = applyToEveryWeek;
            schedule.dayOfWeek = dayOfWeek;
            schedule.deviceId = deviceId;
            schedule.device = device;*/

            //double commmeeeOut = deviceFromCreate.UsageKwH;

            //Console.WriteLine("HELLLOOOOOOO" + form["startTime"].ToString());
            //DateTime startTime = Convert.ToDateTime(form["startTime"].ToString());
            //String abc = form["startTime"].ToString();
            //Schedule schedule = new Schedule();

            //Console.WriteLine("ByeBye" + schedule.endTime);



            if (ModelState.IsValid)
            {

                _ScheduleMapper.Create(schedule).Save().Commit();
                
                return RedirectToAction("Index1");
            }
            return View(schedule);
        }

        // GET: Scheduler/Edit/5
        public ActionResult Edit(ObjectId id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Schedule schedule = _ScheduleMapper.SelectById(id);
            if (schedule == null)
            {
                return NotFound();
            }
            //Device aDevice = dataGateway2.SelectById(schedule.deviceId);
            //ViewBag.dID = schedule.deviceId;
            //ViewBag.dName = aDevice.DeviceName;
            //ViewBag.dType = aDevice.Type;
            //ViewBag.dStatusWhenOn = schedule.statusWhenOn;
            //ViewBag.dStartTime = schedule.startTime;
            //ViewBag.dEndTime = schedule.endTime;
            //return View(schedule;
            return View();
        }

        // POST: Scheduler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("ScheduleId,deviceId,startTime,endTime,applyToEveryWeek,dayOfWeek,statusWhenOn")] Schedule schedule)
        {
            //if (id != schedule.ScheduleId)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        dataGateway.Update(schedule);
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!ScheduleExists(schedule.ScheduleId))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(schedule);
            return View();
        }

        // GET: Scheduler/Delete/5
        public ActionResult Delete(ObjectId id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Schedule schedule = _ScheduleMapper.SelectById(id);
            if (schedule == null)
            {
                return NotFound();
            }
            //Device aDevice = dataGateway2.SelectById(schedule.deviceId);
            //ViewBag.dName = aDevice.DeviceName;
            //return View(schedule);
            return View();
        }

        // POST: Scheduler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(ObjectId id)
        {
            _ScheduleMapper.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(ObjectId id)
        {
            Schedule schedule = new Schedule();
            if ((schedule = _ScheduleMapper.SelectById(id)) != null)
                return true;
            return false;
        }

        // <summary>
        // Serialize a Device object for use in view
        // </summary>
        // <param name="data"></param>
        // <returns></returns>
        public string Serialize<Device>(Device data)
        {
            string functionReturnValue = string.Empty;

            using (var memoryStream = new MemoryStream())
            {
                var serializer = new DataContractSerializer(typeof(Device));
                serializer.WriteObject(memoryStream, data);

                memoryStream.Seek(0, SeekOrigin.Begin);

                var reader = new StreamReader(memoryStream);
                functionReturnValue = reader.ReadToEnd();
            }

            return functionReturnValue;
        }

        // <summary>
        // Deserialize object
        // </summary>
        // <param name="data"></param>
        // <returns>Object<Device></returns>
        public Device Deserialize<Device>(string data)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                var serializer = new DataContractSerializer(typeof(Device));
                Device theObject = (Device)serializer.ReadObject(stream);
                return theObject;
            }
        }

        //Temporary Device Object
        public Device ADevice()
        { 
            FanDevice sampleDevice = new FanDevice();

            ObjectId houseId = new ObjectId("5ac26535276cca1f46f54bc3");
            ObjectId scheduleId = new ObjectId("5ac5abcf630e212034b3a32c");

            sampleDevice._id = new ObjectId("5ac609b14589ec02bcff878c");
            sampleDevice.HouseholdId = houseId;
            sampleDevice.Name = "Living Room Fan";
            sampleDevice.Location = "Living Room";
            sampleDevice.Type = "Fan";
            sampleDevice.State = "Off";
            sampleDevice.KWh = 20;
            sampleDevice.Brand = "Akira";
            sampleDevice.Model = "ST-88F";
            sampleDevice.IsFavourite = true;
            sampleDevice.TimeStamp = new DateTime(2009, 01, 01, 06, 36, 00);
            sampleDevice.FanSpeed = 3;

            return sampleDevice;
        }
    }
}
