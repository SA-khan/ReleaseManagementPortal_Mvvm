using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.BindingTargets
{
    public class DatabaseData
    {
        [Required]
        public string Name { get => Database.Name; set => Database.Name = value; }
        public long? DatabaseVendor { 
            get => Database.DatabaseVendor?.DatabaseVendorId ?? null ; 
            set
            {
                if (!value.HasValue)
                {
                    Database.DatabaseVendor = null;
                }
                else
                {
                    if(Database.DatabaseVendor == null)
                    {
                        Database.DatabaseVendor = new DatabaseVendor();
                    }
                    Database.DatabaseVendor.DatabaseVendorId = value.Value;
                }
            }
        }
        public long? Product {
            get => Database.Product?.ProductId ?? null;
            set
            {
                if (!value.HasValue)
                {
                    Database.Product = null;
                }
                else
                {
                    if(Database.Product == null)
                    {
                        Database.Product = new Product();
                    }
                    Database.Product.ProductId = value.Value;
                }
            }
        }
        public long? Environment { 
            get => Database.Environment?.EnvironmentId ?? null; 
            set
            {
                if (!value.HasValue)
                {
                    Database.Environment = null;
                }
                else
                {
                    if(Database.Environment == null)
                    {
                        Database.Environment = new Environment();
                    }
                    Database.Environment.EnvironmentId = value.Value;
                }
            } 
        }
        //public Models.OperatingSystem OperatingSystem { get; set; }
        public bool Main { get => Database.Main; set => Database.Main = value; }
        public long? Server { 
            get => Database.Server?.ServerId ?? null;
            set {
                if (!value.HasValue)
                {
                    Database.Server = null;
                }
                else
                {
                    if(Database.Server == null)
                    {
                        Database.Server = new Server();
                    }
                    Database.Server.ServerId = value.Value;
                }
            }
        }
        public string Instance { get => Database.Instance; set => Database.Instance = value; }
        public string Hash { get => Database.Hash; set => Database.Hash = value; }
        public long? MdfInformation { 
            get => Database.MdfInformation?.DataLogFileId ?? null;
            set {
                if (!value.HasValue)
                {
                    Database.MdfInformation = null;
                }
                else
                {
                    if(Database.MdfInformation == null)
                    {
                        Database.MdfInformation = new DataLogFile();
                    }
                    Database.MdfInformation.DataLogFileId = value.Value;
                }
            } 
        }
        public long? LdfInformation
        {
            get => Database.LdfInformation?.DataLogFileId ?? null;
            set {
                if (!value.HasValue)
                {
                    Database.LdfInformation = null;
                }
                else
                {
                    if(Database.LdfInformation == null)
                    {
                        Database.LdfInformation = new DataLogFile();
                    }
                    Database.LdfInformation.DataLogFileId = value.Value;
                }
            }
        }
        public DateTime LastBackUpDate { get => Database.LastBackUpDate; set => Database.LastBackUpDate = value; }
        public string BackUpFileName { get => Database.BackUpFileName; set => Database.BackUpFileName = value; }
        public string BackUpFileLocation { get => Database.BackUpFileLocation; set => Database.BackUpFileLocation = value; }
        public long? BackupTakenPOC
        {
            get => Database.BackupTakenPOC?.UserId ?? null;
            set {
                if (!value.HasValue)
                {
                    Database.BackupTakenPOC = null;
                }
                else
                {
                    if(Database.BackupTakenPOC == null)
                    {
                        Database.BackupTakenPOC = new User();
                    }
                    Database.BackupTakenPOC.UserId = value.Value;
                }
            }
        }
        public DateTime LastRestoredDate { get => Database.LastRestoredDate; set => Database.LastRestoredDate = value; }
        public string RestoredFileName { get => Database.RestoredFileName; set => Database.RestoredFileName = value; }
        public long? RestoredPOC
        {
            get => Database.RestoredPOC?.UserId ?? null;
            set {
                if (!value.HasValue)
                {
                    Database.RestoredPOC = null;
                }
                else
                {
                    if(Database.RestoredPOC == null)
                    {
                        Database.RestoredPOC = new User();
                    }
                    Database.RestoredPOC.UserId = value.Value;
                }
            }
        }
        public string Comments { get => Database.Comments; set => Database.Comments = value; }
        public Database Database { get; set; } = new Database();
    }
}
