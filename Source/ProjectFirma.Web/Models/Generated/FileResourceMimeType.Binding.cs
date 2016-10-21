//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FileResourceMimeType]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public abstract partial class FileResourceMimeType : IHavePrimaryKey
    {
        public static readonly FileResourceMimeTypePDF PDF = FileResourceMimeTypePDF.Instance;
        public static readonly FileResourceMimeTypeWordDOCX WordDOCX = FileResourceMimeTypeWordDOCX.Instance;
        public static readonly FileResourceMimeTypeExcelXLSX ExcelXLSX = FileResourceMimeTypeExcelXLSX.Instance;
        public static readonly FileResourceMimeTypeXPNG XPNG = FileResourceMimeTypeXPNG.Instance;
        public static readonly FileResourceMimeTypePNG PNG = FileResourceMimeTypePNG.Instance;
        public static readonly FileResourceMimeTypeTIFF TIFF = FileResourceMimeTypeTIFF.Instance;
        public static readonly FileResourceMimeTypeBMP BMP = FileResourceMimeTypeBMP.Instance;
        public static readonly FileResourceMimeTypeGIF GIF = FileResourceMimeTypeGIF.Instance;
        public static readonly FileResourceMimeTypeJPEG JPEG = FileResourceMimeTypeJPEG.Instance;
        public static readonly FileResourceMimeTypePJPEG PJPEG = FileResourceMimeTypePJPEG.Instance;
        public static readonly FileResourceMimeTypePowerpointPPTX PowerpointPPTX = FileResourceMimeTypePowerpointPPTX.Instance;
        public static readonly FileResourceMimeTypePowerpointPPT PowerpointPPT = FileResourceMimeTypePowerpointPPT.Instance;
        public static readonly FileResourceMimeTypeExcelXLS ExcelXLS = FileResourceMimeTypeExcelXLS.Instance;
        public static readonly FileResourceMimeTypeWordDOC WordDOC = FileResourceMimeTypeWordDOC.Instance;
        public static readonly FileResourceMimeTypexExcelXLSX xExcelXLSX = FileResourceMimeTypexExcelXLSX.Instance;

        public static readonly List<FileResourceMimeType> All;
        public static readonly ReadOnlyDictionary<int, FileResourceMimeType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static FileResourceMimeType()
        {
            All = new List<FileResourceMimeType> { PDF, WordDOCX, ExcelXLSX, XPNG, PNG, TIFF, BMP, GIF, JPEG, PJPEG, PowerpointPPTX, PowerpointPPT, ExcelXLS, WordDOC, xExcelXLSX };
            AllLookupDictionary = new ReadOnlyDictionary<int, FileResourceMimeType>(All.ToDictionary(x => x.FileResourceMimeTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected FileResourceMimeType(int fileResourceMimeTypeID, string fileResourceMimeTypeName, string fileResourceMimeTypeDisplayName, string fileResourceMimeTypeContentTypeName, string fileResourceMimeTypeIconSmallFilename, string fileResourceMimeTypeIconNormalFilename)
        {
            FileResourceMimeTypeID = fileResourceMimeTypeID;
            FileResourceMimeTypeName = fileResourceMimeTypeName;
            FileResourceMimeTypeDisplayName = fileResourceMimeTypeDisplayName;
            FileResourceMimeTypeContentTypeName = fileResourceMimeTypeContentTypeName;
            FileResourceMimeTypeIconSmallFilename = fileResourceMimeTypeIconSmallFilename;
            FileResourceMimeTypeIconNormalFilename = fileResourceMimeTypeIconNormalFilename;
        }

        [Key]
        public int FileResourceMimeTypeID { get; private set; }
        public string FileResourceMimeTypeName { get; private set; }
        public string FileResourceMimeTypeDisplayName { get; private set; }
        public string FileResourceMimeTypeContentTypeName { get; private set; }
        public string FileResourceMimeTypeIconSmallFilename { get; private set; }
        public string FileResourceMimeTypeIconNormalFilename { get; private set; }
        public int PrimaryKey { get { return FileResourceMimeTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(FileResourceMimeType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.FileResourceMimeTypeID == FileResourceMimeTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as FileResourceMimeType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return FileResourceMimeTypeID;
        }

        public static bool operator ==(FileResourceMimeType left, FileResourceMimeType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FileResourceMimeType left, FileResourceMimeType right)
        {
            return !Equals(left, right);
        }

        public FileResourceMimeTypeEnum ToEnum { get { return (FileResourceMimeTypeEnum)GetHashCode(); } }

        public static FileResourceMimeType ToType(int enumValue)
        {
            return ToType((FileResourceMimeTypeEnum)enumValue);
        }

        public static FileResourceMimeType ToType(FileResourceMimeTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case FileResourceMimeTypeEnum.BMP:
                    return BMP;
                case FileResourceMimeTypeEnum.ExcelXLS:
                    return ExcelXLS;
                case FileResourceMimeTypeEnum.ExcelXLSX:
                    return ExcelXLSX;
                case FileResourceMimeTypeEnum.GIF:
                    return GIF;
                case FileResourceMimeTypeEnum.JPEG:
                    return JPEG;
                case FileResourceMimeTypeEnum.PDF:
                    return PDF;
                case FileResourceMimeTypeEnum.PJPEG:
                    return PJPEG;
                case FileResourceMimeTypeEnum.PNG:
                    return PNG;
                case FileResourceMimeTypeEnum.PowerpointPPT:
                    return PowerpointPPT;
                case FileResourceMimeTypeEnum.PowerpointPPTX:
                    return PowerpointPPTX;
                case FileResourceMimeTypeEnum.TIFF:
                    return TIFF;
                case FileResourceMimeTypeEnum.WordDOC:
                    return WordDOC;
                case FileResourceMimeTypeEnum.WordDOCX:
                    return WordDOCX;
                case FileResourceMimeTypeEnum.xExcelXLSX:
                    return xExcelXLSX;
                case FileResourceMimeTypeEnum.XPNG:
                    return XPNG;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum FileResourceMimeTypeEnum
    {
        PDF = 1,
        WordDOCX = 2,
        ExcelXLSX = 3,
        XPNG = 4,
        PNG = 5,
        TIFF = 6,
        BMP = 7,
        GIF = 8,
        JPEG = 9,
        PJPEG = 10,
        PowerpointPPTX = 11,
        PowerpointPPT = 12,
        ExcelXLS = 13,
        WordDOC = 14,
        xExcelXLSX = 15
    }

    public partial class FileResourceMimeTypePDF : FileResourceMimeType
    {
        private FileResourceMimeTypePDF(int fileResourceMimeTypeID, string fileResourceMimeTypeName, string fileResourceMimeTypeDisplayName, string fileResourceMimeTypeContentTypeName, string fileResourceMimeTypeIconSmallFilename, string fileResourceMimeTypeIconNormalFilename) : base(fileResourceMimeTypeID, fileResourceMimeTypeName, fileResourceMimeTypeDisplayName, fileResourceMimeTypeContentTypeName, fileResourceMimeTypeIconSmallFilename, fileResourceMimeTypeIconNormalFilename) {}
        public static readonly FileResourceMimeTypePDF Instance = new FileResourceMimeTypePDF(1, @"PDF", @"PDF", @"application/pdf", @"/Content/img/MimeTypeIcons/pdf_20x20.png", @"/Content/img/MimeTypeIcons/pdf_48x48.png");
    }

    public partial class FileResourceMimeTypeWordDOCX : FileResourceMimeType
    {
        private FileResourceMimeTypeWordDOCX(int fileResourceMimeTypeID, string fileResourceMimeTypeName, string fileResourceMimeTypeDisplayName, string fileResourceMimeTypeContentTypeName, string fileResourceMimeTypeIconSmallFilename, string fileResourceMimeTypeIconNormalFilename) : base(fileResourceMimeTypeID, fileResourceMimeTypeName, fileResourceMimeTypeDisplayName, fileResourceMimeTypeContentTypeName, fileResourceMimeTypeIconSmallFilename, fileResourceMimeTypeIconNormalFilename) {}
        public static readonly FileResourceMimeTypeWordDOCX Instance = new FileResourceMimeTypeWordDOCX(2, @"Word (DOCX)", @"Word (DOCX)", @"application/vnd.openxmlformats-officedocument.wordprocessingml.document", @"/Content/img/MimeTypeIcons/word_20x20.png", @"/Content/img/MimeTypeIcons/word_48x48.png");
    }

    public partial class FileResourceMimeTypeExcelXLSX : FileResourceMimeType
    {
        private FileResourceMimeTypeExcelXLSX(int fileResourceMimeTypeID, string fileResourceMimeTypeName, string fileResourceMimeTypeDisplayName, string fileResourceMimeTypeContentTypeName, string fileResourceMimeTypeIconSmallFilename, string fileResourceMimeTypeIconNormalFilename) : base(fileResourceMimeTypeID, fileResourceMimeTypeName, fileResourceMimeTypeDisplayName, fileResourceMimeTypeContentTypeName, fileResourceMimeTypeIconSmallFilename, fileResourceMimeTypeIconNormalFilename) {}
        public static readonly FileResourceMimeTypeExcelXLSX Instance = new FileResourceMimeTypeExcelXLSX(3, @"Excel (XLSX)", @"Excel (XLSX)", @"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", @"/Content/img/MimeTypeIcons/excel_20x20.png", @"/Content/img/MimeTypeIcons/excel_48x48.png");
    }

    public partial class FileResourceMimeTypeXPNG : FileResourceMimeType
    {
        private FileResourceMimeTypeXPNG(int fileResourceMimeTypeID, string fileResourceMimeTypeName, string fileResourceMimeTypeDisplayName, string fileResourceMimeTypeContentTypeName, string fileResourceMimeTypeIconSmallFilename, string fileResourceMimeTypeIconNormalFilename) : base(fileResourceMimeTypeID, fileResourceMimeTypeName, fileResourceMimeTypeDisplayName, fileResourceMimeTypeContentTypeName, fileResourceMimeTypeIconSmallFilename, fileResourceMimeTypeIconNormalFilename) {}
        public static readonly FileResourceMimeTypeXPNG Instance = new FileResourceMimeTypeXPNG(4, @"X-PNG", @"X-PNG", @"image/x-png", null, null);
    }

    public partial class FileResourceMimeTypePNG : FileResourceMimeType
    {
        private FileResourceMimeTypePNG(int fileResourceMimeTypeID, string fileResourceMimeTypeName, string fileResourceMimeTypeDisplayName, string fileResourceMimeTypeContentTypeName, string fileResourceMimeTypeIconSmallFilename, string fileResourceMimeTypeIconNormalFilename) : base(fileResourceMimeTypeID, fileResourceMimeTypeName, fileResourceMimeTypeDisplayName, fileResourceMimeTypeContentTypeName, fileResourceMimeTypeIconSmallFilename, fileResourceMimeTypeIconNormalFilename) {}
        public static readonly FileResourceMimeTypePNG Instance = new FileResourceMimeTypePNG(5, @"PNG", @"PNG", @"image/png", null, null);
    }

    public partial class FileResourceMimeTypeTIFF : FileResourceMimeType
    {
        private FileResourceMimeTypeTIFF(int fileResourceMimeTypeID, string fileResourceMimeTypeName, string fileResourceMimeTypeDisplayName, string fileResourceMimeTypeContentTypeName, string fileResourceMimeTypeIconSmallFilename, string fileResourceMimeTypeIconNormalFilename) : base(fileResourceMimeTypeID, fileResourceMimeTypeName, fileResourceMimeTypeDisplayName, fileResourceMimeTypeContentTypeName, fileResourceMimeTypeIconSmallFilename, fileResourceMimeTypeIconNormalFilename) {}
        public static readonly FileResourceMimeTypeTIFF Instance = new FileResourceMimeTypeTIFF(6, @"TIFF", @"TIFF", @"image/tiff", null, null);
    }

    public partial class FileResourceMimeTypeBMP : FileResourceMimeType
    {
        private FileResourceMimeTypeBMP(int fileResourceMimeTypeID, string fileResourceMimeTypeName, string fileResourceMimeTypeDisplayName, string fileResourceMimeTypeContentTypeName, string fileResourceMimeTypeIconSmallFilename, string fileResourceMimeTypeIconNormalFilename) : base(fileResourceMimeTypeID, fileResourceMimeTypeName, fileResourceMimeTypeDisplayName, fileResourceMimeTypeContentTypeName, fileResourceMimeTypeIconSmallFilename, fileResourceMimeTypeIconNormalFilename) {}
        public static readonly FileResourceMimeTypeBMP Instance = new FileResourceMimeTypeBMP(7, @"BMP", @"BMP", @"image/bmp", null, null);
    }

    public partial class FileResourceMimeTypeGIF : FileResourceMimeType
    {
        private FileResourceMimeTypeGIF(int fileResourceMimeTypeID, string fileResourceMimeTypeName, string fileResourceMimeTypeDisplayName, string fileResourceMimeTypeContentTypeName, string fileResourceMimeTypeIconSmallFilename, string fileResourceMimeTypeIconNormalFilename) : base(fileResourceMimeTypeID, fileResourceMimeTypeName, fileResourceMimeTypeDisplayName, fileResourceMimeTypeContentTypeName, fileResourceMimeTypeIconSmallFilename, fileResourceMimeTypeIconNormalFilename) {}
        public static readonly FileResourceMimeTypeGIF Instance = new FileResourceMimeTypeGIF(8, @"GIF", @"GIF", @"image/gif", null, null);
    }

    public partial class FileResourceMimeTypeJPEG : FileResourceMimeType
    {
        private FileResourceMimeTypeJPEG(int fileResourceMimeTypeID, string fileResourceMimeTypeName, string fileResourceMimeTypeDisplayName, string fileResourceMimeTypeContentTypeName, string fileResourceMimeTypeIconSmallFilename, string fileResourceMimeTypeIconNormalFilename) : base(fileResourceMimeTypeID, fileResourceMimeTypeName, fileResourceMimeTypeDisplayName, fileResourceMimeTypeContentTypeName, fileResourceMimeTypeIconSmallFilename, fileResourceMimeTypeIconNormalFilename) {}
        public static readonly FileResourceMimeTypeJPEG Instance = new FileResourceMimeTypeJPEG(9, @"JPEG", @"JPEG", @"image/jpeg", null, null);
    }

    public partial class FileResourceMimeTypePJPEG : FileResourceMimeType
    {
        private FileResourceMimeTypePJPEG(int fileResourceMimeTypeID, string fileResourceMimeTypeName, string fileResourceMimeTypeDisplayName, string fileResourceMimeTypeContentTypeName, string fileResourceMimeTypeIconSmallFilename, string fileResourceMimeTypeIconNormalFilename) : base(fileResourceMimeTypeID, fileResourceMimeTypeName, fileResourceMimeTypeDisplayName, fileResourceMimeTypeContentTypeName, fileResourceMimeTypeIconSmallFilename, fileResourceMimeTypeIconNormalFilename) {}
        public static readonly FileResourceMimeTypePJPEG Instance = new FileResourceMimeTypePJPEG(10, @"PJPEG", @"PJPEG", @"image/pjpeg", null, null);
    }

    public partial class FileResourceMimeTypePowerpointPPTX : FileResourceMimeType
    {
        private FileResourceMimeTypePowerpointPPTX(int fileResourceMimeTypeID, string fileResourceMimeTypeName, string fileResourceMimeTypeDisplayName, string fileResourceMimeTypeContentTypeName, string fileResourceMimeTypeIconSmallFilename, string fileResourceMimeTypeIconNormalFilename) : base(fileResourceMimeTypeID, fileResourceMimeTypeName, fileResourceMimeTypeDisplayName, fileResourceMimeTypeContentTypeName, fileResourceMimeTypeIconSmallFilename, fileResourceMimeTypeIconNormalFilename) {}
        public static readonly FileResourceMimeTypePowerpointPPTX Instance = new FileResourceMimeTypePowerpointPPTX(11, @"Powerpoint (PPTX)", @"Powerpoint (PPTX)", @"application/vnd.openxmlformats-officedocument.presentationml.presentation", @"/Content/img/MimeTypeIcons/powerpoint_20x20.png", @"/Content/img/MimeTypeIcons/powerpoint_48x48.png");
    }

    public partial class FileResourceMimeTypePowerpointPPT : FileResourceMimeType
    {
        private FileResourceMimeTypePowerpointPPT(int fileResourceMimeTypeID, string fileResourceMimeTypeName, string fileResourceMimeTypeDisplayName, string fileResourceMimeTypeContentTypeName, string fileResourceMimeTypeIconSmallFilename, string fileResourceMimeTypeIconNormalFilename) : base(fileResourceMimeTypeID, fileResourceMimeTypeName, fileResourceMimeTypeDisplayName, fileResourceMimeTypeContentTypeName, fileResourceMimeTypeIconSmallFilename, fileResourceMimeTypeIconNormalFilename) {}
        public static readonly FileResourceMimeTypePowerpointPPT Instance = new FileResourceMimeTypePowerpointPPT(12, @"Powerpoint (PPT)", @"Powerpoint (PPT)", @"application/vnd.ms-powerpoint", @"/Content/img/MimeTypeIcons/powerpoint_20x20.png", @"/Content/img/MimeTypeIcons/powerpoint_48x48.png");
    }

    public partial class FileResourceMimeTypeExcelXLS : FileResourceMimeType
    {
        private FileResourceMimeTypeExcelXLS(int fileResourceMimeTypeID, string fileResourceMimeTypeName, string fileResourceMimeTypeDisplayName, string fileResourceMimeTypeContentTypeName, string fileResourceMimeTypeIconSmallFilename, string fileResourceMimeTypeIconNormalFilename) : base(fileResourceMimeTypeID, fileResourceMimeTypeName, fileResourceMimeTypeDisplayName, fileResourceMimeTypeContentTypeName, fileResourceMimeTypeIconSmallFilename, fileResourceMimeTypeIconNormalFilename) {}
        public static readonly FileResourceMimeTypeExcelXLS Instance = new FileResourceMimeTypeExcelXLS(13, @"Excel (XLS)", @"Excel (XLS)", @"application/vnd.ms-excel", @"/Content/img/MimeTypeIcons/excel_20x20.png", @"/Content/img/MimeTypeIcons/excel_48x48.png");
    }

    public partial class FileResourceMimeTypeWordDOC : FileResourceMimeType
    {
        private FileResourceMimeTypeWordDOC(int fileResourceMimeTypeID, string fileResourceMimeTypeName, string fileResourceMimeTypeDisplayName, string fileResourceMimeTypeContentTypeName, string fileResourceMimeTypeIconSmallFilename, string fileResourceMimeTypeIconNormalFilename) : base(fileResourceMimeTypeID, fileResourceMimeTypeName, fileResourceMimeTypeDisplayName, fileResourceMimeTypeContentTypeName, fileResourceMimeTypeIconSmallFilename, fileResourceMimeTypeIconNormalFilename) {}
        public static readonly FileResourceMimeTypeWordDOC Instance = new FileResourceMimeTypeWordDOC(14, @"Word (DOC)", @"Word (DOC)", @"application/msword", @"/Content/img/MimeTypeIcons/word_20x20.png", @"/Content/img/MimeTypeIcons/word_48x48.png");
    }

    public partial class FileResourceMimeTypexExcelXLSX : FileResourceMimeType
    {
        private FileResourceMimeTypexExcelXLSX(int fileResourceMimeTypeID, string fileResourceMimeTypeName, string fileResourceMimeTypeDisplayName, string fileResourceMimeTypeContentTypeName, string fileResourceMimeTypeIconSmallFilename, string fileResourceMimeTypeIconNormalFilename) : base(fileResourceMimeTypeID, fileResourceMimeTypeName, fileResourceMimeTypeDisplayName, fileResourceMimeTypeContentTypeName, fileResourceMimeTypeIconSmallFilename, fileResourceMimeTypeIconNormalFilename) {}
        public static readonly FileResourceMimeTypexExcelXLSX Instance = new FileResourceMimeTypexExcelXLSX(15, @"x-Excel (XLSX)", @"x-Excel (XLSX)", @"application/x-excel", @"/Content/img/MimeTypeIcons/excel_20x20.png", @"/Content/img/MimeTypeIcons/excel_48x48.png");
    }
}