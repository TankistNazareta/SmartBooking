dotnet ef migrations add FirstMigration --project ../SmartBooking.Infrastructure --startup-project ./ --output-dir ../SmartBooking.Infrastructure/Persistence/Migrations

dotnet ef database update --project ../SmartBooking.Infrastructure --startup-project ./

dotnet ef migrations remove --project ../SmartBooking.Infrastructure --startup-project ./
