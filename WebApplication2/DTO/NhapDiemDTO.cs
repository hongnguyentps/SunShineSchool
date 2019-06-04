using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.POCO;

namespace WebApplication2.DTO
{
    public class DiemDTO
    {
        public int DiemId { get; set; }
        public double? DiemSo { get; set; }

        public string UserId { get; set; }

        public string LopId { get; set; }

        public string MonHocMaMH { get; set; }

        public string HocKyMaHKy { get; set; }

        public string LoaiDiemId { get; set; }

        public string DiemTB { get; set; }

        public string GhiChu { get; set; }
    }

    public class LayDanhSachLopForDiemDto
    {
        public List<DiemCaNhan> DiemCaNhans { get; set; }

        public string LopId { get; set; }

        public string MonHocId { get; set; }

        public string GVBMId { get; set; }

        public string GetXepLoai()
        {
            var diem = GetDiemTB();
            if (diem >= 8) return "Giỏi";
            if (diem >= 6.5 && diem < 8) return "Khá";
            if (diem < 6.5 && diem >= 5) return "Trung bình";
            if (diem < 5) return "Yếu";
            return string.Empty;
        }

        public double GetDiemTB()
        {
            return DiemCaNhans.Sum(m => m.GetDiemTb()) / DiemCaNhans.Count;
        }
    }

    public class DiemCaNhan
    {
        public string MaNgDung { get; set; }

        public string Ho { get; set; }

        public string Ten { get; set; }

        public string GioiTinh { get; set; }

        public DateTime NgaySinh { get; set; }

        public List<DiemDetail> DiemMiengs { get; set; }

        public List<DiemDetail> Diem15ps { get; set; }

        public List<DiemDetail> Diem1Tiets { get; set; }

        public List<DiemDetail> DiemGiuaKys { get; set; }

        public List<DiemDetail> DiemCuoiKys { get; set; }

        public string GetXepLoai()
        {
            var diem = GetDiemTb();
            if (diem >= 8) return "Giỏi";
            if (diem >= 6.5 && diem < 8) return "Khá";
            if (diem < 6.5 && diem >= 5) return "Trung bình";
            if (diem < 5) return "Yếu";
            return string.Empty;
        }

        public double GetDiemTb()
        {
            double tongDiem = 0;
            var heso = 0;
            foreach (var diemMieng in DiemMiengs)
            {
                tongDiem += diemMieng.Diem;
                heso++;
            }
            foreach (var diem15p in Diem15ps)
            {
                tongDiem += diem15p.Diem;
                heso++;
            }
            foreach (var diem1Tiet in Diem1Tiets)
            {
                tongDiem += diem1Tiet.Diem * 2;
                heso = heso + 2;
            }
            foreach (var DiemGiuaKys in DiemGiuaKys)
            {
                tongDiem += DiemGiuaKys.Diem * 2;
                heso = heso + 2;
            }
            foreach (var DiemCuoiKys in DiemCuoiKys)
            {
                tongDiem += DiemCuoiKys.Diem * 3;
                heso = heso + 3;
            }

            if (tongDiem == 0 || heso == 0) return 0;
            return (tongDiem / heso);
        }
    }

    public class DiemDetail
    {
        public double Diem { get; set; }
        public int DiemId { get; set; }
    }
}
