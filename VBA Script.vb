Public Sub Stock_market_data_loop()


Dim ws As Worksheet
Dim wb As Workbook

Set wb = ActiveWorkbook



For Each ws In Worksheets

  Dim Ticker_Symbol, Max_Ticker_Symbol, Max_Volume_tricker_Symbol, Min_Ticker_Symbol As String
  Ticker_Symbol = " "
  Max_Ticker_Symbol = " "
  Max_Volume_Ticker_Symbol = " "
  Min_Ticker_Symbol = " "


  Dim Total_Stock_Volume, Opening_Price, Closing_Price, Yearly_Change, Percent_change, Max_percent, Min_Percent, Max_Volume As Double
  Total_Stock_Volume = 0
  Opening_Price = 0
  Closing_Price = 0
  Yearly_Change = 0
  Percent_change = 0
  Max_percent = 0
  Min_Percent = 0
  Max_Volume = 0
  
  Dim Summary_Row, LastRow As Long
  Summary_Row = 2
  LastRow = ws.Cells(Rows.Count, 1).End(xlUp).Row
  
  ws.Range("I1").Value = "Ticker"
  ws.Range("J1").Value = "Yearly Change"
  ws.Range("K1").Value = "Percent Change"
  ws.Range("L1").Value = "Total Stock Volume"
  ws.Range("P1").Value = "Ticker"
  ws.Range("Q1").Value = "Value"



  Opening_Price = ws.Cells(2, 3).Value

  For i = 2 To LastRow
     If ws.Cells(i + 1, 1).Value <> ws.Cells(i, 1).Value Then
        Ticker_Symbol = ws.Cells(i, 1).Value
        Closing_Price = ws.Cells(i, 6).Value
        Yearly_Change = Closing_Price - Opening_Price

        If Opening_Price <> 0 Then
        Percent_change = (Yearly_Change / Opening_Price) * 100

        End If

        Total_Stock_Volume = Total_Stock_Volume + ws.Cells(i, 7).Value
       
        ws.Range("I" & Summary_Row).Value = Ticker_Symbol

        ws.Range("j" & Summary_Row).Value = Yearly_Change


        If Yearly_Change > 0 Then
        
        ws.Range("J" & Summary_Row).Interior.ColorIndex = 4

        ElseIf Yearly_Change <= 0 Then
        
        ws.Range("J" & Summary_Row).Interior.ColorIndex = 3

        End If

        ws.Range("K" & Summary_Row).Value = (CStr(Percent_change) & "%")

        ws.Range("L" & Summary_Row).Value = Total_Stock_Volume

        Summary_Row = Summary_Row + 1

        Opening_Price = ws.Cells(i + 1, 3).Value

        If (Percent_change > Max_percent) Then
        Max_percent = Percent_change
        Max_Ticker_Symbol = Ticker_Symbol


        ElseIf (Percent_change < Min_Percent) Then
        Min_Percent = Percent_change
        Min_Ticker_Symbol = Ticker_Symbol


        End If

        If (Total_Stock_Volume > Max_Volume) Then
        Max_Volume = Total_Stock_Volume
        Max_Volume_Ticker_Symbol = Ticker_Symbol

        End If

        Percent_change = 0
        Total_Stock_Volume = 0

   Else
   Total_Stock_Volume = Total_Stock_Volume + ws.Cells(i, 7).Value

   End If

Next i

ws.Range("O2").Value = "Greatest % Increase"
ws.Range("O3").Value = "Greatest % Decrease"
ws.Range("O4").Value = "Greatest total Volume"
ws.Range("P2").Value = Max_Ticker_Symbol
ws.Range("P3").Value = Min_Ticker_Symbol
ws.Range("P4").Value = Max_Volume_Ticker_Symbol
ws.Range("Q2").Value = (CStr(Max_percent) & "%")
ws.Range("Q3").Value = (CStr(Min_Percent) & "%")
ws.Range("Q4").Value = Max_Volume


Next ws

End Sub