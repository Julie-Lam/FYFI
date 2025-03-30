CREATE TABLE [dbo].[MonthlyCapture] (
    [MonthlyCaptureId]   INT      IDENTITY (1, 1) NOT NULL,
    [MonthlyCaptureDate] DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([MonthlyCaptureId] ASC)
);

