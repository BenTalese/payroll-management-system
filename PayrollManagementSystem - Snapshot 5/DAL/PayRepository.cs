using Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PayRepository
    {
        string _cs = ConfigurationManager.ConnectionStrings["PayrollDB"].ConnectionString;

        //---------------------------------------------------//
        //---------- PAYSLIP PROCESSING OPERATIONS ----------//
        //---------------------------------------------------//

        public IEnumerable<Payslip> GetPayslips()
        {
            Console.WriteLine(">> Retrieving list of payslips from DB");
            var payslips = new List<Payslip>();

            using (var connection = new SqlConnection(_cs))
            using (var command = new SqlCommand("SELECT * FROM dbo.Payslip", connection))
            {
                // 0 = payID, 1 = empID, 2 = periodStart, 3 = periodEnd, 4 = hours, 5 = gross, 6 = net, 7 = tax, 8 = state
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int pID = reader.GetInt32(0);
                    int eID = reader.GetInt32(1);
                    DateTime payStart = reader.GetDateTime(2);
                    DateTime payEnd = reader.GetDateTime(3);
                    decimal hours = reader.GetDecimal(4);
                    decimal gross = reader.GetDecimal(5);
                    decimal net = reader.GetDecimal(6);
                    decimal tax = reader.GetDecimal(7);
                    int stateID = reader.GetInt32(8);
                    
                    var payslip = new Payslip(pID, eID, payStart, payEnd, hours, gross, net, tax, stateID);
                    payslips.Add(payslip);
                }
                return payslips;
            }
        }


        public void UpdatePayState(Payslip p)
        {
            using (var connection = new SqlConnection(_cs))
            using (var command = new SqlCommand("UPDATE Payslip SET PayStateID = @stateID WHERE PayslipID = @pID", connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@pID", p.PayslipID);
                command.Parameters.AddWithValue("@stateID", (int)p.State);
                command.ExecuteNonQuery();
            }
        }

        public void DeletePayslip(Payslip p)
        {
            using (var connection = new SqlConnection(_cs))
            using (var command = new SqlCommand("DELETE FROM Payslip WHERE PayslipID = @pID", connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@pID", p.PayslipID);
                command.ExecuteNonQuery();
            }
        }

        //---------------------------------------------------//
        //------------- ROSTER REPO OPERATIONS --------------//
        //---------------------------------------------------//

        // insert rostered shift
        public void InsertRosteredShift(Employee e, Shift s)
        {
            Console.WriteLine(">> Inserting rostered shift into DB");
            using (var connection = new SqlConnection(_cs))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "INSERT INTO dbo.RosteredShift (EmployeeID,ShiftID) VALUES (@e, @s)";
                command.Parameters.AddWithValue("@e", e.EmployeeID);
                command.Parameters.AddWithValue("@s", s.ShiftID);
                command.ExecuteNonQuery();
            }
        }
        // delete rostered shift


        // get all rostered shifts
        public IEnumerable<RosteredShift> GetRosteredShifts()
        {
            Console.WriteLine(">> Retrieving list of rostered shifts from DB");
            var rosteredShifts = new List<RosteredShift>();
            using (var connection = new SqlConnection(_cs))
            using (var command = new SqlCommand("SELECT * FROM dbo.RosteredShift", connection))
            {
                // 0 = employeeID, 1 = shiftID
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int empID = reader.GetInt32(0);
                    int sftID = reader.GetInt32(1);

                    var rostered = new RosteredShift(empID, sftID);
                    rosteredShifts.Add(rostered);
                }
                return rosteredShifts;
            }
        }

        // get shifts only for specific employee via ID
        public IEnumerable<Shift> GetRosteredShiftsByEmployeeID(int id)
        {
            Console.WriteLine(">> Retrieving list of rostered shifts from DB");
            var rosteredShifts = new List<Shift>();
            using (var connection = new SqlConnection(_cs))
            using (var command = new SqlCommand("sp_SelectRosteredShiftsByEmployeeID @id", connection))
            {
                command.Parameters.AddWithValue("@id", id);
                // 0 = ShiftID, 1 = ShiftDate, 2 = StartTime, 3 = EndTime
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int sID = reader.GetInt32(0);
                    DateTime date = reader.GetDateTime(1);
                    TimeSpan sTime = reader.GetTimeSpan(2);
                    TimeSpan eTime = reader.GetTimeSpan(3);

                    rosteredShifts.Add(new Shift(sID, date, sTime, eTime));
                }
                return rosteredShifts;
            }
        }



        //---------------------------------------------------//
        //--------------- EMPLOYEE RETRIEVAL ----------------//
        //---------------------------------------------------//

        // retrieve a list of employee objects from the db
        public IEnumerable<Employee> GetEmployees()
        {
            Console.WriteLine(">> Retrieving list of employees from DB");
            var employees = new List<Employee>();
            using (var connection = new SqlConnection(_cs))
            using (var command = new SqlCommand("SELECT * FROM dbo.Employee", connection))
            {
                // 0 = id, 1 = fName, 2 = lName, 3 = rate, 4 = ytd
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string fName = reader.GetString(1);
                    string lName = reader.GetString(2);
                    decimal rate = reader.GetDecimal(3);
                    decimal ytd = reader.GetDecimal(4);

                    var emp = new Employee(id, fName, lName, rate, ytd);
                    employees.Add(emp);
                }
            }
            return employees;
        }

        // retrieve ONLY the specified employee by its ID
        public Employee GetEmployee(int id)
        {
            Console.WriteLine($">> Retrieving employee with ID of {id} from DB");
            Employee emp = null;
            using (var connection = new SqlConnection(_cs))
            using (var command = new SqlCommand("SELECT * FROM dbo.Employee WHERE EmployeeID = @id", connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", id);
                using (var reader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow))
                {
                    reader.Read();
                    string fName = reader.GetString(1);
                    string lName = reader.GetString(2);
                    decimal rate = reader.GetDecimal(3);
                    decimal ytd = reader.GetDecimal(4);

                    emp = new Employee(id, fName, lName, rate, ytd);
                }
            }
            return emp;
        }



        //---------------------------------------------------//
        //---------------- SHIFT RETRIEVAL ------------------//
        //---------------------------------------------------//

        // retrieve a list of shift objects from the db
        public IEnumerable<Shift> GetShifts()
        {
            Console.WriteLine(">> Retrieving list of shifts from DB");
            var shifts = new List<Shift>();
            using (var connection = new SqlConnection(_cs))
            using (var command = new SqlCommand("SELECT * FROM dbo.Shift", connection))
            {
                // 0 = id, 1 = date, 2 = start, 3 = end
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    DateTime date = reader.GetDateTime(1);
                    TimeSpan sTime = reader.GetTimeSpan(2);
                    TimeSpan eTime = reader.GetTimeSpan(3);

                    var sft = new Shift(id, date, sTime, eTime);
                    shifts.Add(sft);
                }
            }
            return shifts;
        }

        // retrieve ONLY the specified shift by its ID
        public Shift GetShift(int id)
        {
            Console.WriteLine($">> Retrieving shift with ID of {id} from DB");
            Shift sft = null;
            using (var connection = new SqlConnection(_cs))
            using (var command = new SqlCommand("SELECT * FROM dbo.Shift WHERE ShiftID = @id", connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", id);
                using (var reader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow))
                {
                    reader.Read();
                    DateTime date = reader.GetDateTime(1);
                    TimeSpan sTime = reader.GetTimeSpan(2);
                    TimeSpan eTime = reader.GetTimeSpan(3);

                    sft = new Shift(id, date, sTime, eTime);
                }
            }
            return sft;
        }

        public void InsertShift(Shift s)
        {
            Console.WriteLine(">> Adding new shift into DB");
            using (var connection = new SqlConnection(_cs))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "INSERT INTO dbo.Shift (ShiftDate,StartTime,EndTime) VALUES (@dt, @st, @et)";
                command.Parameters.AddWithValue("@dt", s.ShiftDate);
                command.Parameters.AddWithValue("@st", s.StartTime);
                command.Parameters.AddWithValue("@et", s.EndTime);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteShift(int id)
        {
            if (shiftNotRostered(id))
            {
                Console.WriteLine($">> Deleting shift with ID of {id} from DB");
                using (var connection = new SqlConnection(_cs))
                using (var command = new SqlCommand("DELETE FROM dbo.Shift WHERE ShiftID = @id", connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                throw new InvalidPayStateException("cannot delete a shift that has been used in a roster");
            }
        }

        private bool shiftNotRostered(int id)
        {
            var rostered = GetRosteredShifts();
            foreach (var roster in rostered)
            {
                if (roster.ShiftID == id)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
