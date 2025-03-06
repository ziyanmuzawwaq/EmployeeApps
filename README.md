## Panduan Instalasi

1.  Instal .NET SDK.
2.  Clone repositori.
3.  Buka terminal dan navigasi ke direktori proyek.
4.  Jalankan `dotnet restore`.
5.  Jalankan `dotnet ef migrations add InitialCreate`.
6.  Jalankan `dotnet ef database update`.
7.  Jalankan `dotnet run`.

## Dummy Data

* Departemen:
    * Nama: Information Technology
    * Nama: Human Resource
    * Nama: Finance
* Karyawan:
    * Nama: Adi, DepartmentId: 1
    * Nama: Abi, DepartmentId: 2
    * Nama: Aji, DepartmentId: 2
