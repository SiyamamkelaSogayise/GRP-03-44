using GeeksProject02.Data;
using GeeksProject02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.Style;
using OfficeOpenXml;

namespace GeeksProject02.Controllers
{
    public class VaccineInventoryController : Controller
    {
        private readonly GeeksProject02Context dbcontext;
        public VaccineInventoryController(GeeksProject02Context dbcontext)
        {
                this.dbcontext = dbcontext;
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var stock = await dbcontext.Stocks.ToListAsync();
            return View(stock);
        }

        [HttpGet]
        public async Task<ActionResult> Add()
        {
            var model = new AddInventoryViewModel();
            return await Task.Run(() => View("Add", model));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddInventoryViewModel addInventoryRequest)
        {
            if (addInventoryRequest != null)
            {
                var stock = new Stock()
                {
                    VaccineName = addInventoryRequest.VaccineName,
                    Brand = addInventoryRequest.Brand,
                    Presentation = addInventoryRequest.Presentation,
                    DosesPerBox = addInventoryRequest.DosesPerBox,
                    PresentationBoxLotNumbers = addInventoryRequest.PresentationBoxLotNumbers,
                    PresentationBoxExpirationDate = addInventoryRequest.PresentationBoxExpirationDate,
                    DoseLotNumbers = addInventoryRequest.DoseLotNumbers,
                    DoseExpirationDate = addInventoryRequest.DoseExpirationDate,
                    DosesOnHand = addInventoryRequest.DosesOnHand,
                    TotalDosesOnHand = addInventoryRequest.TotalDosesOnHand,
                    Status = addInventoryRequest.Status,

                };
                await dbcontext.Stocks.AddAsync(stock);
                await dbcontext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                // Handle the case where addVacineRequest is null
                return RedirectToAction("Index"); // or return an error view
            }

        }
        [HttpGet]
        public async Task<IActionResult> View(int Id)
        {
            var stock = await dbcontext.Stocks.FirstOrDefaultAsync(x => x.Id == Id);
            if (stock != null)
            {
                var viewModel = new AddInventoryViewModel()
                {

                    VaccineName = stock.VaccineName,
                    Brand = stock.Brand,
                    Presentation = stock.Presentation,
                    DosesPerBox = stock.DosesPerBox,
                    PresentationBoxLotNumbers = stock.PresentationBoxLotNumbers,
                    PresentationBoxExpirationDate  = stock.PresentationBoxExpirationDate,
                    DoseLotNumbers = stock.DoseLotNumbers,
                    DoseExpirationDate = stock.DoseExpirationDate,
                    DosesOnHand = stock.DosesOnHand,
                    TotalDosesOnHand = stock.TotalDosesOnHand,
                    Status = stock.Status,

                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public async Task<IActionResult> View(AddInventoryViewModel model)
        {
            var stock = await dbcontext.Stocks.FindAsync(model.Id);
            if (stock != null)
            {
                stock.VaccineName = model.VaccineName;
                stock.Brand = model.Brand;
                stock.Presentation = model.Presentation;
                stock.DosesPerBox = model.DosesPerBox;
                stock.PresentationBoxLotNumbers= model.PresentationBoxLotNumbers;
                stock.PresentationBoxExpirationDate = model.PresentationBoxExpirationDate;
                stock.DoseLotNumbers = model.DoseLotNumbers;
                stock.DoseExpirationDate = model.DoseExpirationDate;
                stock.DosesOnHand  = model.DosesOnHand;
                stock.TotalDosesOnHand= model.TotalDosesOnHand;
                stock.Status = model.Status;


                await dbcontext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ExportToExcel()
        {
            var stockList = dbcontext.Stocks.ToList();

            var stream = new MemoryStream();
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("VaccineInventory");

                // Add headers
                var headers = new string[]
                {
                    "ID", "Vaccine Name", "Vaccine Brand", "Presentation", "DosesPerBox", "PresentationBoxLotNumbers",
                    "PresentationBoxExpirationDate", "DoseLotNumbers", "DoseExpirationDate", "DosesOnHand",
                    "TotalDosesOnHand", "Status"
                };

                for (int i = 1; i <= headers.Length; i++)
                {
                    worksheet.Cells[1, i].Value = headers[i - 1];
                    worksheet.Cells[1, i].Style.Font.Bold = true;
                    worksheet.Cells[1, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[1, i].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                }

                // Add data
                for (int i = 0; i < stockList.Count; i++)
                {
                    var item = stockList[i];
                    worksheet.Cells[i + 2, 1].Value = item.Id;
                    worksheet.Cells[i + 2, 2].Value = item.VaccineName;
                    worksheet.Cells[i + 2, 3].Value = item.Brand;
                    worksheet.Cells[i + 2, 4].Value = item.Presentation;
                    worksheet.Cells[i + 2, 5].Value = item.DosesPerBox;
                    worksheet.Cells[i + 2, 6].Value = item.PresentationBoxLotNumbers;
                    worksheet.Cells[i + 2, 7].Value = item.PresentationBoxExpirationDate;
                    worksheet.Cells[i + 2, 8].Value = item.DoseLotNumbers;
                    worksheet.Cells[i + 2, 9].Value = item.DoseExpirationDate;
                    worksheet.Cells[i + 2, 10].Value = item.DosesOnHand;
                    worksheet.Cells[i + 2, 11].Value = item.TotalDosesOnHand;
                    worksheet.Cells[i + 2, 12].Value = item.Status;
                }

                package.Save();
            }

            stream.Position = 0;
            string excelName = $"VaccineInventory_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
    }
}
