USE [gameshop]
GO

/****** Object:  Table [dbo].[OrderEntries]    Script Date: 11.06.2017 17:48:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderEntries](
	[order_id] [int] NOT NULL,
	[item_id] [int] NOT NULL,
	[quantity] [int] NULL,
 CONSTRAINT [PK_OrderEntries] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC,
	[item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OrderEntries]  WITH CHECK ADD  CONSTRAINT [FK_OrderEntries_Items] FOREIGN KEY([item_id])
REFERENCES [dbo].[Items] ([item_id])
GO

ALTER TABLE [dbo].[OrderEntries] CHECK CONSTRAINT [FK_OrderEntries_Items]
GO

ALTER TABLE [dbo].[OrderEntries]  WITH CHECK ADD  CONSTRAINT [FK_OrderEntries_Orders] FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([order_id])
GO

ALTER TABLE [dbo].[OrderEntries] CHECK CONSTRAINT [FK_OrderEntries_Orders]
GO


