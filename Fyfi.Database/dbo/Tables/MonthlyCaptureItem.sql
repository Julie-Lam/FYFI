CREATE TABLE [dbo].[MonthlyCaptureItem] (
    [MonthlyCaptureItemId] INT           IDENTITY (1, 1) NOT NULL,
    [MonthlyCaptureId]     INT           NULL,
    [ItemName]             VARCHAR (MAX) NULL,
    [ItemAmount]           DECIMAL (18)  NULL,
    PRIMARY KEY CLUSTERED ([MonthlyCaptureItemId] ASC),
    FOREIGN KEY ([MonthlyCaptureId]) REFERENCES [dbo].[MonthlyCapture] ([MonthlyCaptureId])
);

