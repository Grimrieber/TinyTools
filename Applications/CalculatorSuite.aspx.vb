Imports System.Data
Imports System.Text.RegularExpressions
Partial Class CalculatorSuite
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Full list of calculators
            Dim calculators As New List(Of String) From {"Algebra Solver",
                "BMI / Body Fat Calculator",
                "BMR Calculator",
                "Break-even Calculator",
                "Caloric Intake Calculator",
                "Car Loan Calculator",
                "Chemistry Molarity Calculator",
                "Compound Interest Calculator",
                "Cryptocurrency ROI Calculator",
                "Currency Converter",
                "Goal Achievement Planner",
                "Heart Rate / Target Zone Calculator",
                "Inventory Turnover Calculator",
                "Internal Rate of Return (IRR) Calculator",
                "Loan Amortization Calculator",
                "Macro Nutrient Calculator",
                "Markup / Margin Calculator",
                "Mortgage Calculator",
                "Net Present Value (NPV) Calculator",
                "Pet Weight / Dosage Calculator",
                "Physics Calculator",
                "Price / Profit Calculator",
                "Pregnancy Calorie Calculator",
                "Productivity Calculator",
                "Quadratic Equation Solver",
                "Retirement Planner",
                "ROI Calculator",
                "Savings Goal Calculator",
                "Sleep Needs Calculator",
                "Stock Investment Calculator",
                "Study / Learning Time Planner",
                "TDEE Calculator",
                "Travel / Fuel Cost Calculator",
                "Unit Conversion Calculator",
                "VAT / Tax Calculator",
                "Water Intake Calculator",
                "Pomodoro / Focus Timer",
                "Body Surface Area Calculator"
            }

            ' Alphabetically sort the list
            calculators = calculators.OrderBy(Function(c) c).ToList()

            ' Bind to dropdown
            ddlCalculators.DataSource = calculators
            ddlCalculators.DataBind()
            'ddlCalculators.Items.Insert(0, New ListItem("-- Select Calculator --", ""))
        End If
    End Sub

    Protected Sub ddlCalculators_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Switch the MultiView to the selected calculator
        Select Case ddlCalculators.SelectedValue
            Case "Algebra Solver"
                mvCalculators.SetActiveView(viewAlgebraAdvanced)
                pnlAlgebra.DefaultButton = btnAlgEval.UniqueID
            Case "BMI / Body Fat Calculator"
                mvCalculators.SetActiveView(viewBMI)
                pnlBMI.DefaultButton = btnBMICalc.UniqueID
            Case "BMR Calculator"
                mvCalculators.SetActiveView(viewBMR)
                pnlBMR.DefaultButton = btnBMRCalc.UniqueID
            Case "Break-even Calculator"
                mvCalculators.SetActiveView(viewBreakEven)
                pnlBreakEven.DefaultButton = btnBreakEvenCalc.UniqueID
            Case "Caloric Intake Calculator"
                mvCalculators.SetActiveView(viewCalorieIntake)
                pnlCalorie.DefaultButton = btnCalorieCalc.UniqueID
            Case "Car Loan Calculator"
                mvCalculators.SetActiveView(viewCarLoan)
                pnlCarLoan.DefaultButton = btnCarLoanCalc.UniqueID
            Case "Chemistry Molarity Calculator"
                mvCalculators.SetActiveView(viewChemistryMolarity)
                pnlMolarity.DefaultButton = btnMolarityCalc.UniqueID
            Case "Compound Interest Calculator" : mvCalculators.SetActiveView(viewCompoundInterest)
            Case "Cryptocurrency ROI Calculator" : mvCalculators.SetActiveView(viewCryptoROI)
            Case "Currency Converter" : mvCalculators.SetActiveView(viewCurrencyConverter)
            Case "Goal Achievement Planner" : mvCalculators.SetActiveView(viewGoalPlanner)
            Case "Heart Rate / Target Zone Calculator" : mvCalculators.SetActiveView(viewHeartRate)
            Case "Inventory Turnover Calculator" : mvCalculators.SetActiveView(viewInventoryTurnover)
            Case "Internal Rate of Return (IRR) Calculator" : mvCalculators.SetActiveView(viewIRR)
            Case "Loan Amortization Calculator" : mvCalculators.SetActiveView(viewLoanAmort)
            Case "Macro Nutrient Calculator" : mvCalculators.SetActiveView(viewMacro)
            Case "Markup / Margin Calculator" : mvCalculators.SetActiveView(viewMarkupMargin)
            Case "Mortgage Calculator" : mvCalculators.SetActiveView(viewMortgageCalc)
            Case "Net Present Value (NPV) Calculator" : mvCalculators.SetActiveView(viewNPV)
            Case "Pet Weight / Dosage Calculator" : mvCalculators.SetActiveView(viewPetDosage)
            Case "Physics Calculator" : mvCalculators.SetActiveView(viewPhysics)
            Case "Price / Profit Calculator" : mvCalculators.SetActiveView(viewPriceProfit)
            Case "Pregnancy Calorie Calculator" : mvCalculators.SetActiveView(viewPregnancyCalorie)
            Case "Productivity Calculator" : mvCalculators.SetActiveView(viewProductivity)
            Case "Quadratic Equation Solver" : mvCalculators.SetActiveView(viewQuadratic)
            Case "Retirement Planner" : mvCalculators.SetActiveView(viewRetirement)
            Case "ROI Calculator" : mvCalculators.SetActiveView(viewROI)
            Case "Savings Goal Calculator" : mvCalculators.SetActiveView(viewSavingsGoal)
            Case "Sleep Needs Calculator" : mvCalculators.SetActiveView(viewSleepNeeds)
            Case "Stock Investment Calculator" : mvCalculators.SetActiveView(viewStockInvestment)
            Case "Study / Learning Time Planner" : mvCalculators.SetActiveView(viewStudyPlanner)
            Case "TDEE Calculator" : mvCalculators.SetActiveView(viewTDEE)
            Case "Travel / Fuel Cost Calculator" : mvCalculators.SetActiveView(viewTravelFuel)
            Case "Unit Conversion Calculator" : mvCalculators.SetActiveView(viewUnitConversion)
            Case "VAT / Tax Calculator" : mvCalculators.SetActiveView(viewVAT)
            Case "Water Intake Calculator" : mvCalculators.SetActiveView(viewWaterIntake)
            Case "Pomodoro / Focus Timer" : mvCalculators.SetActiveView(viewPomodoro)
            Case "Chemistry Molarity Calculator" : mvCalculators.SetActiveView(viewChemistryMolarity)
            Case "Body Surface Area Calculator" : mvCalculators.SetActiveView(viewBSA)
        End Select
    End Sub

    Protected Sub btnAlgEval_Click(sender As Object, e As EventArgs)
        Dim input As String = txtAlgExpression.Text.Trim()
        Dim output As String = ""

        ' Solve or evaluate
        If input.Contains("=") Then
            output = SolveLinearEquation(input)
        Else
            output = EvaluateExpression(input)
        End If

        ' Format input and output as numbers if possible
        Dim formattedInput As String = input
        Dim formattedOutput As String = output

        Dim dblInput As Double
        If Double.TryParse(input, dblInput) Then
            formattedInput = dblInput.ToString("#,##0.##")
        End If

        Dim dblOutput As Double
        If Double.TryParse(output, dblOutput) Then
            formattedOutput = dblOutput.ToString("#,##0.##")
        End If

        ' Show latest result in label
        lblAlgResult.Text = "Output: " & formattedOutput

        ' Prepend new history entry at the top
        Dim newHistory As String = DateTime.Now.ToString("HH:mm:ss") & " | Input: " & formattedInput.PadRight(12) & " | Output: " & formattedOutput.PadRight(12)
        'txtAlgHistory.Text = newHistory & vbCrLf & txtAlgHistory.Text
        ' Build formatted entry (you already have formattedInput/formattedOutput)
        Dim newEntry As String = DateTime.Now.ToString("HH:mm:ss") & " | Input: " & formattedInput.PadRight(12) & " | Output: " & formattedOutput.PadRight(12)

        ' Prepend encoded entry to existing InnerHtml. Replace CRLF with <br/>
        divAlgHistory.InnerHtml = Server.HtmlEncode(newEntry).Replace(vbCrLf, "<br/>") & "<br/>" & divAlgHistory.InnerHtml


        ' Clear input
        txtAlgExpression.Text = ""
        txtAlgExpression.Focus()
    End Sub


    Protected Sub btnAlgClear_Click(sender As Object, e As EventArgs)
        'txtAlgHistory.Text = ""
        divAlgHistory.InnerHtml = ""
        lblAlgResult.Text = ""
    End Sub

    ' Evaluate numeric expression
    Private Function EvaluateExpression(expr As String) As String
        Try
            Dim dt As New DataTable()
            dt.CaseSensitive = False
            Dim result As Object = dt.Compute(expr, "")
            Return result.ToString()
        Catch ex As Exception
            Return "Error: Invalid numeric expression."
        End Try
    End Function

    ' Solve simple linear equation: ax + b = c
    Private Function SolveLinearEquation(equation As String) As String
        Try
            Dim parts() As String = equation.Split("="c)
            If parts.Length <> 2 Then Return "Error: Invalid equation format."

            Dim left As String = parts(0).Trim()
            Dim right As String = parts(1).Trim()

            Dim match As Match = Regex.Match(left, "([+-]?\d*\.?\d*)\*?([a-zA-Z])")
            If Not match.Success Then Return "Error: Could not find variable."

            Dim coeffStr As String = match.Groups(1).Value
            Dim variable As String = match.Groups(2).Value

            Dim coeff As Double
            If String.IsNullOrEmpty(coeffStr) Or coeffStr = "+" Then
                coeff = 1
            ElseIf coeffStr = "-" Then
                coeff = -1
            Else
                coeff = Double.Parse(coeffStr)
            End If

            Dim leftConstStr As String = Regex.Replace(left, "([+-]?\d*\.?\d*)\*?" & variable, "")
            Dim leftConst As Double = 0
            If Not String.IsNullOrWhiteSpace(leftConstStr) Then
                leftConst = Double.Parse(EvaluateExpression(leftConstStr))
            End If

            Dim rightVal As Double = Double.Parse(EvaluateExpression(right))
            Dim x As Double = (rightVal - leftConst) / coeff

            Return variable & " = " & x.ToString()
        Catch ex As Exception
            Return "Error: Could not solve equation."
        End Try
    End Function

    Protected Sub btnBMICalc_Click(sender As Object, e As EventArgs) Handles btnBMICalc.Click
        Dim weight As Double
        Dim heightCm As Double
        Dim age As Integer
        Dim gender As String = ddlBMIGender.SelectedValue
        Dim result As String = ""

        ' Validate weight
        If Not Double.TryParse(txtBMIWeight.Text, weight) OrElse weight <= 0 Then
            lblBMIResult.Text = "Please enter a valid weight."
            Return
        End If

        ' Convert weight to kg if input is in lb
        Dim displayWeightUnit As String = ddlBMIWeightUnit.SelectedValue
        If displayWeightUnit = "lb" Then
            weight = weight * 0.453592
        End If

        ' Validate height
        If Not Double.TryParse(txtBMIHeight.Text, heightCm) OrElse heightCm <= 0 Then
            lblBMIResult.Text = "Please enter a valid height."
            Return
        End If

        ' Convert height to cm if input is in inches
        Dim displayHeightUnit As String = ddlBMIHeightUnit.SelectedValue
        If displayHeightUnit = "in" Then
            heightCm = heightCm * 2.54
        End If

        ' Validate age
        If Not Integer.TryParse(txtBMIAge.Text, age) OrElse age <= 0 Then
            lblBMIResult.Text = "Please enter a valid age."
            Return
        End If

        ' Convert height to meters
        Dim heightM As Double = heightCm / 100

        ' Calculate BMI
        Dim bmi As Double = weight / (heightM * heightM)

        ' Determine BMI category
        Dim bmiCategory As String = ""
        Select Case bmi
            Case < 18.5
                bmiCategory = "Underweight"
            Case 18.5 To 24.9
                bmiCategory = "Normal weight"
            Case 25 To 29.9
                bmiCategory = "Overweight"
            Case >= 30
                bmiCategory = "Obese"
        End Select

        ' Estimate Body Fat Percentage (US Navy method approximation)
        Dim bodyFat As Double
        If gender = "M" Then
            bodyFat = 1.2 * bmi + 0.23 * age - 16.2
        Else
            bodyFat = 1.2 * bmi + 0.23 * age - 5.4
        End If

        ' Healthy weight range for BMI 18.5-24.9
        Dim minHealthyWeight As Double = 18.5 * (heightM * heightM)
        Dim maxHealthyWeight As Double = 24.9 * (heightM * heightM)

        ' Convert outputs back to user's selected units
        If displayWeightUnit = "lb" Then
            minHealthyWeight *= 2.20462
            maxHealthyWeight *= 2.20462
        End If

        ' Prepare result string
        result &= $"BMI: {bmi:F2} ({bmiCategory}) <br/>"
        result &= $"Estimated Body Fat: {bodyFat:F1}% <br/>"
        result &= $"Healthy Weight Range: {minHealthyWeight:F1}-{maxHealthyWeight:F1} {displayWeightUnit}"

        ' Display results
        lblBMIResult.Text = result

        ' Add to history with timestamp (newest at top)
        Dim historyEntry As String = $"{DateTime.Now:HH:mm:ss} | BMI: {bmi:F2} | Body Fat: {bodyFat:F1}% | Healthy Weight: {minHealthyWeight:F1}-{maxHealthyWeight:F1} {displayWeightUnit}"

        ' Prepend to div history
        divBMIHistory.InnerHtml = Server.HtmlEncode(historyEntry).Replace(vbCrLf, "<br/>") & "<br/>" & divBMIHistory.InnerHtml
    End Sub


    Protected Sub btnBMRCalc_Click(sender As Object, e As EventArgs) Handles btnBMRCalc.Click
        Dim weight As Double
        Dim heightCm As Double
        Dim age As Integer
        Dim gender As String = ddlBMRGender.SelectedValue
        Dim activityFactor As Double = Convert.ToDouble(ddlBMRActivity.SelectedValue)
        Dim result As String = ""

        ' Validate weight
        If Not Double.TryParse(txtBMRWeight.Text, weight) OrElse weight <= 0 Then
            lblBMRResult.Text = "Please enter a valid weight."
            Return
        End If

        ' Convert weight to kg if needed
        If ddlBMRWeightUnit.SelectedValue = "lb" Then
            weight = weight * 0.453592
        End If

        ' Validate height
        If Not Double.TryParse(txtBMRHeight.Text, heightCm) OrElse heightCm <= 0 Then
            lblBMRResult.Text = "Please enter a valid height."
            Return
        End If

        ' Convert height to cm if needed
        If ddlBMRHeightUnit.SelectedValue = "in" Then
            heightCm = heightCm * 2.54
        End If

        ' Validate age
        If Not Integer.TryParse(txtBMRAge.Text, age) OrElse age <= 0 Then
            lblBMRResult.Text = "Please enter a valid age."
            Return
        End If

        ' Calculate BMR using Mifflin-St Jeor Equation
        Dim bmr As Double
        If gender = "M" Then
            bmr = 10 * weight + 6.25 * heightCm - 5 * age + 5
        Else
            bmr = 10 * weight + 6.25 * heightCm - 5 * age - 161
        End If

        ' Calculate TDEE
        Dim tdee As Double = bmr * activityFactor

        ' Format results
        result &= $"BMR: {bmr:F0} kcal/day <br/>"
        result &= $"TDEE (with activity factor): {tdee:F0} kcal/day"
        lblBMRResult.Text = result

        ' Add to history (newest at top)
        Dim historyEntry As String = $"{DateTime.Now:HH:mm:ss} | BMR: {bmr:F0} kcal | TDEE: {tdee:F0} kcal"

        ' Prepend entry to div and maintain line breaks
        divBMRHistory.InnerHtml = Server.HtmlEncode(historyEntry).Replace(vbCrLf, "<br/>") & "<br/>" & divBMRHistory.InnerHtml
    End Sub


    Protected Sub btnBreakEvenCalc_Click(sender As Object, e As EventArgs) Handles btnBreakEvenCalc.Click
        Dim fixedCosts As Double
        Dim pricePerUnit As Double
        Dim variableCostPerUnit As Double
        Dim targetProfit As Double = 0
        Dim result As String = ""

        ' Validate inputs
        If Not Double.TryParse(txtBreakEvenFixed.Text, fixedCosts) OrElse fixedCosts < 0 Then
            lblBreakEvenResult.Text = "Please enter a valid Fixed Costs value."
            Return
        End If

        If Not Double.TryParse(txtBreakEvenPrice.Text, pricePerUnit) OrElse pricePerUnit <= 0 Then
            lblBreakEvenResult.Text = "Please enter a valid Price per Unit."
            Return
        End If

        If Not Double.TryParse(txtBreakEvenVariable.Text, variableCostPerUnit) OrElse variableCostPerUnit < 0 Then
            lblBreakEvenResult.Text = "Please enter a valid Variable Cost per Unit."
            Return
        End If

        ' Optional target profit
        If txtBreakEvenTargetProfit.Text <> "" Then
            Double.TryParse(txtBreakEvenTargetProfit.Text, targetProfit)
        End If

        ' Check if price > variable cost
        If pricePerUnit <= variableCostPerUnit Then
            lblBreakEvenResult.Text = "Price per Unit must be greater than Variable Cost per Unit."
            Return
        End If

        ' Calculate break-even units and revenue
        Dim breakEvenUnits As Double = fixedCosts / (pricePerUnit - variableCostPerUnit)
        Dim breakEvenRevenue As Double = breakEvenUnits * pricePerUnit

        ' Calculate units/revenue for target profit
        Dim targetUnits As Double = (fixedCosts + targetProfit) / (pricePerUnit - variableCostPerUnit)
        Dim targetRevenue As Double = targetUnits * pricePerUnit

        ' Format result label
        result &= $"Break-even Point: {breakEvenUnits:N0} units <br/>"
        result &= $"Break-even Revenue: {breakEvenRevenue:C2} <br/>"

        If targetProfit > 0 Then
            result &= $"Units for Target Profit (${targetProfit:N0}): {targetUnits:N0} <br/>"
            result &= $"Revenue for Target Profit: {targetRevenue:C2}"
        End If

        lblBreakEvenResult.Text = result

        ' Add to history (newest at top)
        Dim historyEntry As String = $"{DateTime.Now:HH:mm:ss} | BE Units: {breakEvenUnits:N0} | BE Revenue: {breakEvenRevenue:C2}"
        If targetProfit > 0 Then
            historyEntry &= $" | Target Units: {targetUnits:N0} | Target Revenue: {targetRevenue:C2}"
        End If

        ' Prepend to div (HTML encode and use <br/>)
        divBreakEvenHistory.InnerHtml = Server.HtmlEncode(historyEntry).Replace(vbCrLf, "<br/>") & "<br/>" & divBreakEvenHistory.InnerHtml
    End Sub
    Protected Sub btnCalorieCalc_Click(sender As Object, e As EventArgs) Handles btnCalorieCalc.Click
        Dim weight As Double
        Dim heightCm As Double
        Dim age As Integer
        Dim gender As String = ddlCalorieGender.SelectedValue
        Dim result As String = ""

        ' --- Validate weight ---
        If Not Double.TryParse(txtCalorieWeight.Text, weight) OrElse weight <= 0 Then
            lblCalorieResult.Text = "Please enter a valid weight."
            Return
        End If
        If ddlCalorieWeightUnit.SelectedValue = "lb" Then weight *= 0.453592

        ' --- Validate height ---
        If Not Double.TryParse(txtCalorieHeight.Text, heightCm) OrElse heightCm <= 0 Then
            lblCalorieResult.Text = "Please enter a valid height."
            Return
        End If
        If ddlCalorieHeightUnit.SelectedValue = "in" Then heightCm *= 2.54

        ' --- Validate age ---
        If Not Integer.TryParse(txtCalorieAge.Text, age) OrElse age <= 0 Then
            lblCalorieResult.Text = "Please enter a valid age."
            Return
        End If

        ' --- Calculate BMR ---
        Dim bmr As Double
        If gender = "M" Then
            bmr = 10 * weight + 6.25 * heightCm - 5 * age + 5
        Else
            bmr = 10 * weight + 6.25 * heightCm - 5 * age - 161
        End If

        ' --- Calculate TDEE ---
        Dim activityFactor As Double = Double.Parse(ddlCalorieActivity.SelectedValue)
        Dim tdee As Double = bmr * activityFactor

        ' --- Fitness goal and macros ---
        Dim fitnessGoal As String = ddlFitnessGoal.SelectedValue
        Dim recommendedCalories As Double = tdee
        Dim proteinPerKg As Double = 2.0
        Dim fatPerc As Double = 0.25
        Dim carbPerc As Double = 0.4 ' realistic cap for carbs
        Select Case fitnessGoal
            Case "lose_standard"
                recommendedCalories = tdee - 500
                proteinPerKg = 2.0
                fatPerc = 0.3
                carbPerc = 0.35
            Case "lose_aggressive"
                recommendedCalories = tdee - 750
                proteinPerKg = 2.2
                fatPerc = 0.3
                carbPerc = 0.35
            Case "maintain"
                recommendedCalories = tdee
                proteinPerKg = 1.8
                fatPerc = 0.25
                carbPerc = 0.4
            Case "gain_lean"
                recommendedCalories = tdee + 300
                proteinPerKg = 2.0
                fatPerc = 0.25
                carbPerc = 0.4
            Case "gain_bulk"
                recommendedCalories = tdee + 500
                proteinPerKg = 2.0
                fatPerc = 0.25
                carbPerc = 0.45
        End Select

        ' --- Calculate macros ---
        Dim proteinGrams As Double = weight * proteinPerKg
        Dim proteinCalories As Double = proteinGrams * 4

        Dim fatCalories As Double = recommendedCalories * fatPerc
        Dim fatGrams As Double = fatCalories / 9

        Dim carbCalories As Double = recommendedCalories * carbPerc
        Dim carbGrams As Double = carbCalories / 4

        ' --- Format result ---
        result = $"BMR: {bmr:F0} kcal/day  <br/> TDEE: {tdee:F0} kcal/day  <br/> Recommended Intake ({fitnessGoal}): {recommendedCalories:F0} kcal/day  <br/> Protein: {proteinGrams:F0} g  <br/> Carbs: {carbGrams:F0} g  <br/> Fat: {fatGrams:F0} g"

        ' --- Display result ---
        lblCalorieResult.Text = result

        ' --- Update macro bars ---
        Dim totalCalories As Double = proteinCalories + fatCalories + carbCalories
        divProteinBar.Style("width") = ((proteinCalories / totalCalories) * 100).ToString("F0") & "%"
        divProteinBar.InnerText = $"Protein {proteinGrams:F0}g"

        divCarbBar.Style("width") = ((carbCalories / totalCalories) * 100).ToString("F0") & "%"
        divCarbBar.InnerText = $"Carbs {carbGrams:F0}g"

        divFatBar.Style("width") = ((fatCalories / totalCalories) * 100).ToString("F0") & "%"
        divFatBar.InnerText = $"Fat {fatGrams:F0}g"

        ' --- Add to history ---
        Dim historyEntry As String = $"{DateTime.Now:HH:mm:ss} | {result}"
        divCalorieHistory.InnerHtml = Server.HtmlEncode(historyEntry).Replace(vbCrLf, "<br/>") & "<br/>" & divCalorieHistory.InnerHtml
    End Sub


    Protected Sub btnCarLoanCalc_Click(sender As Object, e As EventArgs) Handles btnCarLoanCalc.Click
        Dim loanAmount As Double
        Dim annualRate As Double
        Dim termMonths As Integer
        Dim extraPayment As Double = 0

        ' --- Validate inputs ---
        If Not Double.TryParse(txtCarLoanAmount.Text, loanAmount) OrElse loanAmount <= 0 Then
            lblCarLoanResult.Text = "Please enter a valid loan amount."
            Return
        End If

        If Not Double.TryParse(txtCarLoanRate.Text, annualRate) OrElse annualRate < 0 Then
            lblCarLoanResult.Text = "Please enter a valid interest rate."
            Return
        End If

        If Not Integer.TryParse(txtCarLoanMonths.Text, termMonths) OrElse termMonths <= 0 Then
            lblCarLoanResult.Text = "Please enter a valid term in months."
            Return
        End If

        Double.TryParse(txtCarLoanExtra.Text, extraPayment)

        ' --- Monthly interest rate ---
        Dim monthlyRate As Double = annualRate / 100 / 12

        ' --- Standard monthly payment ---
        Dim monthlyPayment As Double
        If monthlyRate = 0 Then
            monthlyPayment = loanAmount / termMonths
        Else
            monthlyPayment = loanAmount * monthlyRate / (1 - Math.Pow(1 + monthlyRate, -termMonths))
        End If

        Dim totalPaid As Double = 0
        Dim totalInterest As Double = 0
        Dim balance As Double = loanAmount
        Dim monthCounter As Integer = 0

        ' --- Amortization table ---
        Dim amortization As New System.Text.StringBuilder()
        amortization.AppendLine("Month | Payment | Interest | Principal | Balance")

        While balance > 0
            monthCounter += 1
            Dim interestPayment As Double = balance * monthlyRate
            Dim principalPayment As Double = monthlyPayment - interestPayment + extraPayment

            ' Ensure we don't pay more than remaining balance
            If principalPayment > balance Then
                principalPayment = balance
            End If

            Dim paymentThisMonth As Double = principalPayment + interestPayment
            balance -= principalPayment

            amortization.AppendLine($"{monthCounter} | {paymentThisMonth:C2} | {interestPayment:C2} | {principalPayment:C2} | {balance:C2}")

            totalPaid += paymentThisMonth
            totalInterest += interestPayment
        End While

        ' --- Format result ---
        Dim result As String = $"Monthly Payment: {monthlyPayment:C2} <br/> Total Paid: {totalPaid:C2} <br/> Total Interest: {totalInterest:C2} <br/> Months to Payoff: {monthCounter}"

        ' --- Display result ---
        lblCarLoanResult.Text = result
        divCarLoanAmortization.InnerHtml = Server.HtmlEncode(amortization.ToString).Replace(vbCrLf, "<br/>")

        ' --- Add to history ---
        Dim historyEntry As String = $"{DateTime.Now:HH:mm:ss} | {result}"
        divCarLoanHistory.InnerHtml = Server.HtmlEncode(historyEntry).Replace(vbCrLf, "<br/>") & "<br/>" & divCarLoanHistory.InnerHtml
    End Sub




    Protected Sub btnMolarityCalc_Click(sender As Object, e As EventArgs) Handles btnMolarityCalc.Click
        Dim amount As Double
        Dim molarMass As Double
        Dim volume As Double

        ' --- Validate solute amount ---
        If Not Double.TryParse(txtAmount.Text, amount) OrElse amount <= 0 Then
            lblMolarityResult.Text = "Please enter a valid solute amount."
            Return
        End If

        ' --- Convert grams to moles if needed ---
        If ddlAmountUnit.SelectedValue = "grams" Then
            If Not Double.TryParse(txtMolarMass.Text, molarMass) OrElse molarMass <= 0 Then
                lblMolarityResult.Text = "Please enter a valid molar mass in g/mol."
                Return
            End If
            amount = amount / molarMass ' Convert grams → moles
        End If

        ' --- Validate volume ---
        If Not Double.TryParse(txtVolume.Text, volume) OrElse volume <= 0 Then
            lblMolarityResult.Text = "Please enter a valid solution volume."
            Return
        End If

        ' --- Convert volume to liters if needed ---
        If ddlVolumeUnit.SelectedValue = "mL" Then
            volume = volume / 1000
        End If

        ' --- Calculate molarity ---
        Dim molarity As Double = amount / volume

        ' --- Format result ---
        Dim result As String = $"Molarity: {molarity:F3} M"

        ' --- Display result ---
        lblMolarityResult.Text = result

        ' --- Add to history ---
        Dim historyEntry As String = $"{DateTime.Now:HH:mm:ss} | {result}"
        divMolarityHistory.InnerHtml = Server.HtmlEncode(historyEntry).Replace(vbCrLf, "<br/>") & "<br/>" & divMolarityHistory.InnerHtml
    End Sub

    Protected Sub btnCICalc_Click(sender As Object, e As EventArgs) Handles btnCICalc.Click
        ' --- Input validation ---
        Dim principal As Double, rate As Double, years As Double
        Dim compoundsPerYear As Integer, extra As Double
        Dim extraFreq As String = ddlCIExtraFreq.SelectedValue

        If Not Double.TryParse(txtCIPrincipal.Text, principal) OrElse principal <= 0 Then
            lblCIResult.Text = "Enter a valid principal."
            Return
        End If
        If Not Double.TryParse(txtCIRate.Text, rate) OrElse rate < 0 Then
            lblCIResult.Text = "Enter a valid interest rate."
            Return
        End If
        If Not Double.TryParse(txtCIYears.Text, years) OrElse years <= 0 Then
            lblCIResult.Text = "Enter a valid number of years."
            Return
        End If
        If Not Integer.TryParse(txtCICompounds.Text, compoundsPerYear) OrElse compoundsPerYear <= 0 Then
            lblCIResult.Text = "Enter a valid number of compounds per year."
            Return
        End If
        If Not Double.TryParse(txtCIExtra.Text, extra) OrElse extra < 0 Then extra = 0

        ' --- Calculate monthly values ---
        Dim totalMonths As Integer = years * 12
        Dim monthlyRate As Double = rate / 100 / 12
        Dim fvNoExtra As Double = principal
        Dim fvWithExtra As Double = principal

        ' Determine monthly extra contribution
        Dim extraPerMonth As Double = 0
        Select Case extraFreq
            Case "monthly"
                extraPerMonth = extra
            Case "quarterly"
                extraPerMonth = extra / 3
            Case "annually"
                extraPerMonth = extra / 12
        End Select

        ' --- Future Value without extra ---
        For m As Integer = 1 To totalMonths
            fvNoExtra *= (1 + monthlyRate)
        Next

        ' --- Future Value with extra ---
        For m As Integer = 1 To totalMonths
            fvWithExtra *= (1 + monthlyRate)
            fvWithExtra += extraPerMonth
        Next

        ' --- Interest calculations ---
        Dim interestNoExtra As Double = fvNoExtra - principal
        Dim totalContributions As Double = extraPerMonth * totalMonths
        Dim interestWithExtra As Double = fvWithExtra - principal - totalContributions

        ' --- Time saved calculation ---
        ' Determine months to reach FV without extra vs. with extra
        Dim targetFV As Double = fvWithExtra
        Dim monthsNoExtra As Double = 0
        Dim balance As Double = principal
        Do While balance < targetFV
            balance *= (1 + monthlyRate)
            monthsNoExtra += 1
            If monthsNoExtra > 1000 Then Exit Do ' prevent infinite loop
        Loop
        Dim timeSavedMonths As Double = monthsNoExtra - totalMonths

        ' --- Format result ---
        Dim result As String = $"Future Value (no extra): ${fvNoExtra:F2} <br/> Interest Earned: ${interestNoExtra:F2} <br/> " &
                           $"With Contributions: ${fvWithExtra:F2} <br/> Interest Earned: ${interestWithExtra:F2} <br/> " &
                           $"Total Contributions: ${totalContributions:F2} <br/> Time Saved: {timeSavedMonths:F1} months"

        lblCIResult.Text = result

        ' --- Add to history ---
        Dim historyEntry As String = $"{DateTime.Now:HH:mm:ss} | {result}"
        divCIHistory.InnerHtml = Server.HtmlEncode(historyEntry).Replace(vbCrLf, "<br/>") & "<br/>" & divCIHistory.InnerHtml
    End Sub

    Protected Sub btnCryptoCalc_Click(sender As Object, e As EventArgs) Handles btnCryptoCalc.Click
        Dim initialInvestment As Double
        Dim finalValue As Double
        Dim years As Double
        Dim extraContribution As Double
        Dim contributionFreq As Integer

        ' --- Validate inputs ---
        If Not Double.TryParse(txtCryptoInvestment.Text, initialInvestment) OrElse initialInvestment <= 0 Then
            lblCryptoResult.Text = "Please enter a valid initial investment."
            Return
        End If
        If Not Double.TryParse(txtCryptoFinal.Text, finalValue) OrElse finalValue <= 0 Then
            lblCryptoResult.Text = "Please enter a valid final value."
            Return
        End If
        If Not Double.TryParse(txtCryptoYears.Text, years) OrElse years <= 0 Then
            lblCryptoResult.Text = "Please enter a valid number of years."
            Return
        End If
        If Not Double.TryParse(txtCryptoContribution.Text, extraContribution) OrElse extraContribution < 0 Then
            lblCryptoResult.Text = "Please enter a valid contribution amount."
            Return
        End If
        contributionFreq = Integer.Parse(ddlCryptoFreq.SelectedValue)

        ' --- Calculate total months ---
        Dim totalMonths As Integer = CInt(years * 12)
        Dim periodMonths As Integer = contributionFreq ' e.g., 1 = monthly, 3 = quarterly

        ' --- Future Value with contributions ---
        Dim fvWithExtra As Double = initialInvestment
        Dim totalContributions As Double = 0
        Dim monthlyRate As Double = (finalValue / initialInvestment) ^ (1 / totalMonths) - 1

        For month As Integer = 1 To totalMonths
            fvWithExtra *= (1 + monthlyRate)
            If month Mod periodMonths = 0 Then
                fvWithExtra += extraContribution
                totalContributions += extraContribution
            End If
        Next

        ' --- Profit calculations ---
        Dim profit As Double = fvWithExtra - initialInvestment
        Dim roiPercent As Double = (profit / initialInvestment) * 100
        Dim annualizedROI As Double = ((fvWithExtra / initialInvestment) ^ (1 / years) - 1) * 100

        ' --- Estimate time saved vs. reaching FV without contributions ---
        Dim fvWithoutExtra As Double = initialInvestment
        Dim monthsWithoutExtra As Integer = 0
        While fvWithoutExtra < fvWithExtra
            fvWithoutExtra *= (1 + monthlyRate)
            monthsWithoutExtra += 1
        End While
        Dim monthsSaved As Integer = monthsWithoutExtra - totalMonths

        ' --- Format result ---
        Dim result As String = $"Profit: ${profit:F2} <br/> ROI: {roiPercent:F2}% <br/> Annualized ROI: {annualizedROI:F2}% <br/> " &
                           $"Total Contributions: ${totalContributions:F2} <br/> Time Saved: {monthsSaved} months"

        ' --- Display result ---
        lblCryptoResult.Text = result

        ' --- Add to history ---
        Dim historyEntry As String = $"{DateTime.Now:HH:mm:ss} | {result}"
        divCryptoHistory.InnerHtml = Server.HtmlEncode(historyEntry).Replace(vbCrLf, "<br/>") & "<br/>" & divCryptoHistory.InnerHtml
    End Sub


    Protected Sub btnCurrencyCalc_Click(sender As Object, e As EventArgs) Handles btnCurrencyCalc.Click
        Dim amount As Double
        Dim rate As Double
        Dim feePercent As Double
        Dim result As String = ""

        ' --- Validate inputs ---
        If Not Double.TryParse(txtCurrencyAmount.Text, amount) OrElse amount <= 0 Then
            lblCurrencyResult.Text = "Please enter a valid amount."
            Return
        End If
        If Not Double.TryParse(txtCurrencyRate.Text, rate) OrElse rate <= 0 Then
            lblCurrencyResult.Text = "Please enter a valid exchange rate."
            Return
        End If
        If Not Double.TryParse(txtCurrencyFee.Text, feePercent) OrElse feePercent < 0 Then
            lblCurrencyResult.Text = "Please enter a valid fee percentage."
            Return
        End If

        ' --- Apply fee/markup ---
        Dim effectiveRate As Double = rate * (1 - feePercent / 100)
        Dim convertedAmount As Double = amount * effectiveRate
        result &= $"Converted Amount: {convertedAmount:F2} (Rate after {feePercent}% fee: {effectiveRate:F4})"

        ' --- Handle additional target currencies ---
        If Not String.IsNullOrWhiteSpace(txtCurrencyExtraRates.Text) Then
            Dim extraRates = txtCurrencyExtraRates.Text.Split(","c)
            result &= "<br/>Additional Conversions:"
            For Each rStr In extraRates
                Dim r As Double
                If Double.TryParse(rStr.Trim(), r) AndAlso r > 0 Then
                    Dim convertedExtra As Double = amount * r * (1 - feePercent / 100)
                    result &= $"<br/>Rate {r:F4} → {convertedExtra:F2}"
                End If
            Next
        End If

        ' --- Display result ---
        lblCurrencyResult.Text = result

        ' --- Add to history ---
        Dim historyEntry As String = $"{DateTime.Now:HH:mm:ss} | {result}"
        divCurrencyHistory.InnerHtml = Server.HtmlEncode(historyEntry).Replace(vbCrLf, "<br/>") & "<br/>" & divCurrencyHistory.InnerHtml
    End Sub


    Protected Sub btnGoalCalc_Click(sender As Object, e As EventArgs) Handles btnGoalCalc.Click
        Dim goalDesc As String = txtGoalDesc.Text.Trim()
        Dim days As Integer

        ' Validate inputs
        If String.IsNullOrEmpty(goalDesc) Then
            lblGoalResult.Text = "Please enter a goal description."
            Return
        End If

        If Not Integer.TryParse(txtGoalDays.Text, days) OrElse days <= 0 Then
            lblGoalResult.Text = "Please enter a valid number of days."
            Return
        End If

        ' Calculate daily action plan
        Dim dailyPlan As String = "To achieve your goal '" & goalDesc & "', try to work on it consistently every day for " & days & " days."

        lblGoalResult.Text = dailyPlan
    End Sub


    Protected Sub btnHRCalc_Click(sender As Object, e As EventArgs) Handles btnHRCalc.Click
        Dim age As Integer

        ' Validate input
        If Not Integer.TryParse(txtHRAge.Text, age) OrElse age <= 0 Then
            lblHRResult.Text = "Please enter a valid age."
            Return
        End If

        ' Maximum heart rate formula
        Dim maxHR As Integer = 220 - age

        ' Target zones (moderate 50-70%, vigorous 70-85%)
        Dim moderateLow As Integer = CInt(maxHR * 0.5)
        Dim moderateHigh As Integer = CInt(maxHR * 0.7)
        Dim vigorousLow As Integer = CInt(maxHR * 0.7)
        Dim vigorousHigh As Integer = CInt(maxHR * 0.85)

        ' Display results
        lblHRResult.Text = $"Maximum Heart Rate: {maxHR} bpm <br/>" &
                       $"Moderate Zone (50-70%): {moderateLow}-{moderateHigh} bpm <br/>" &
                       $"Vigorous Zone (70-85%): {vigorousLow}-{vigorousHigh} bpm"
    End Sub

    Protected Sub btnInventoryCalc_Click(sender As Object, e As EventArgs) Handles btnInventoryCalc.Click
        Dim cogs As Decimal
        Dim avgInventory As Decimal

        ' Validate inputs
        If Not Decimal.TryParse(txtCOGS.Text, cogs) OrElse cogs < 0 Then
            lblInventoryResult.Text = "Please enter a valid Cost of Goods Sold."
            Return
        End If

        If Not Decimal.TryParse(txtAvgInventory.Text, avgInventory) OrElse avgInventory <= 0 Then
            lblInventoryResult.Text = "Please enter a valid Average Inventory greater than 0."
            Return
        End If

        ' Calculate inventory turnover
        Dim turnover As Decimal = cogs / avgInventory

        ' Display result
        lblInventoryResult.Text = $"Inventory Turnover: {turnover:F2}"
    End Sub

    Protected Sub btnIRRCalc_Click(sender As Object, e As EventArgs) Handles btnIRRCalc.Click
        Dim investment As Decimal
        Dim finalValue As Decimal

        ' Validate inputs
        If Not Decimal.TryParse(txtIRRInvestment.Text, investment) OrElse investment <= 0 Then
            lblIRRResult.Text = "Please enter a valid Initial Investment greater than 0."
            Return
        End If

        If Not Decimal.TryParse(txtIRRFinal.Text, finalValue) Then
            lblIRRResult.Text = "Please enter a valid Final Value."
            Return
        End If

        ' Simple IRR approximation: (Final / Initial)^(1/n) - 1
        ' Since we don't have years/duration input, we'll assume 1 year for this basic version
        Dim irr As Decimal = (finalValue / investment) - 1

        ' Display result as percentage
        lblIRRResult.Text = $"Estimated IRR: {irr:P2}"
    End Sub

    Protected Sub btnLoanAmortCalc_Click(sender As Object, e As EventArgs) Handles btnLoanAmortCalc.Click
        Dim principal As Decimal
        Dim annualRate As Decimal
        Dim years As Integer

        ' Validate inputs
        If Not Decimal.TryParse(txtLoanAmt.Text, principal) OrElse principal <= 0 Then
            lblLoanAmortResult.Text = "Enter a valid Loan Amount greater than 0."
            Return
        End If

        If Not Decimal.TryParse(txtLoanInterest.Text, annualRate) OrElse annualRate < 0 Then
            lblLoanAmortResult.Text = "Enter a valid Interest Rate."
            Return
        End If

        If Not Integer.TryParse(txtLoanTerm.Text, years) OrElse years <= 0 Then
            lblLoanAmortResult.Text = "Enter a valid Term in years."
            Return
        End If

        ' Monthly interest rate
        Dim monthlyRate As Decimal = (annualRate / 100D) / 12D
        Dim totalPayments As Integer = years * 12

        ' Amortization formula: M = P * r(1+r)^n / ((1+r)^n - 1)
        Dim monthlyPayment As Decimal
        If monthlyRate = 0 Then
            monthlyPayment = principal / totalPayments
        Else
            monthlyPayment = principal * monthlyRate * CDec(Math.Pow(1 + monthlyRate, totalPayments)) / (CDec(Math.Pow(1 + monthlyRate, totalPayments)) - 1)
        End If

        lblLoanAmortResult.Text = $"Monthly Payment: {monthlyPayment:C2}"
    End Sub


    Protected Sub btnMacroCalc_Click(sender As Object, e As EventArgs) Handles btnMacroCalc.Click
        Dim calories As Decimal
        Dim proteinPct As Decimal
        Dim carbsPct As Decimal
        Dim fatPct As Decimal

        ' Validate inputs
        If Not Decimal.TryParse(txtMacroCalories.Text, calories) OrElse calories <= 0 Then
            lblMacroResult.Text = "Enter a valid Calories value greater than 0."
            Return
        End If

        If Not Decimal.TryParse(txtMacroProtein.Text, proteinPct) OrElse proteinPct < 0 Then
            lblMacroResult.Text = "Enter a valid Protein %."
            Return
        End If

        If Not Decimal.TryParse(txtMacroCarbs.Text, carbsPct) OrElse carbsPct < 0 Then
            lblMacroResult.Text = "Enter a valid Carbs %."
            Return
        End If

        If Not Decimal.TryParse(txtMacroFat.Text, fatPct) OrElse fatPct < 0 Then
            lblMacroResult.Text = "Enter a valid Fat %."
            Return
        End If

        Dim totalPct As Decimal = proteinPct + carbsPct + fatPct
        If totalPct = 0 Then
            lblMacroResult.Text = "Total macro percentages cannot be zero."
            Return
        End If

        ' Calculate grams
        Dim proteinGrams As Decimal = (proteinPct / totalPct) * calories / 4D
        Dim carbsGrams As Decimal = (carbsPct / totalPct) * calories / 4D
        Dim fatGrams As Decimal = (fatPct / totalPct) * calories / 9D

        lblMacroResult.Text = $"Protein: {Math.Round(proteinGrams, 2)} g, Carbs: {Math.Round(carbsGrams, 2)} g, Fat: {Math.Round(fatGrams, 2)} g"
    End Sub


    Protected Sub btnMarkupCalc_Click(sender As Object, e As EventArgs) Handles btnMarkupCalc.Click
        Dim cost As Decimal
        Dim price As Decimal

        ' Validate inputs
        If Not Decimal.TryParse(txtCost.Text, cost) OrElse cost < 0 Then
            lblMarkupResult.Text = "Enter a valid Cost."
            Return
        End If

        If Not Decimal.TryParse(txtPrice.Text, price) OrElse price < 0 Then
            lblMarkupResult.Text = "Enter a valid Price."
            Return
        End If

        If cost = 0 Then
            lblMarkupResult.Text = "Cost cannot be zero for markup calculation."
            Return
        End If

        ' Calculate markup and margin
        Dim markupPct As Decimal = ((price - cost) / cost) * 100
        Dim marginPct As Decimal = ((price - cost) / price) * 100

        lblMarkupResult.Text = $"Markup: {Math.Round(markupPct, 2)}%, Margin: {Math.Round(marginPct, 2)}%"
    End Sub


    Protected Sub btnMortgageCalc_Click(sender As Object, e As EventArgs) Handles btnMortgageCalc.Click
        Dim principal As Decimal
        Dim annualRate As Decimal
        Dim years As Integer

        ' Validate inputs
        If Not Decimal.TryParse(txtMortgageAmt.Text, principal) OrElse principal <= 0 Then
            lblMortgageResult.Text = "Enter a valid Loan Amount."
            Return
        End If

        If Not Decimal.TryParse(txtMortgageInterest.Text, annualRate) OrElse annualRate < 0 Then
            lblMortgageResult.Text = "Enter a valid Interest Rate."
            Return
        End If

        If Not Integer.TryParse(txtMortgageTerm.Text, years) OrElse years <= 0 Then
            lblMortgageResult.Text = "Enter a valid Term in years."
            Return
        End If

        ' Monthly interest rate
        Dim monthlyRate As Decimal = (annualRate / 100) / 12
        Dim totalPayments As Integer = years * 12

        ' Calculate monthly payment using formula: P = (r*L) / (1-(1+r)^-n)
        Dim monthlyPayment As Decimal
        If monthlyRate = 0 Then
            monthlyPayment = principal / totalPayments
        Else
            monthlyPayment = (monthlyRate * principal) / (1 - Math.Pow(1 + monthlyRate, -totalPayments))
        End If

        lblMortgageResult.Text = $"Monthly Payment: {Math.Round(monthlyPayment, 2):C}"
    End Sub


    Protected Sub btnNPVCalc_Click(sender As Object, e As EventArgs) Handles btnNPVCalc.Click
        Dim initialInvestment As Decimal
        Dim futureValue As Decimal
        Dim discountRate As Decimal

        ' Validate inputs
        If Not Decimal.TryParse(txtNPVInvestment.Text, initialInvestment) Then
            lblNPVResult.Text = "Enter a valid Initial Investment."
            Return
        End If

        If Not Decimal.TryParse(txtNPVFuture.Text, futureValue) Then
            lblNPVResult.Text = "Enter a valid Future Value."
            Return
        End If

        If Not Decimal.TryParse(txtNPVRate.Text, discountRate) Then
            lblNPVResult.Text = "Enter a valid Discount Rate."
            Return
        End If

        ' Convert percentage to decimal
        discountRate = discountRate / 100

        ' Assume 1 period for simplicity: NPV = FV / (1+r)^n - Initial
        Dim npv As Decimal = futureValue / (1 + discountRate) - initialInvestment

        lblNPVResult.Text = $"NPV: {Math.Round(npv, 2):C}"
    End Sub

    Protected Sub btnPetCalc_Click(sender As Object, e As EventArgs) Handles btnPetCalc.Click
        Dim weight As Decimal
        Dim dosePerKg As Decimal

        ' Validate inputs
        If Not Decimal.TryParse(txtPetWeight.Text, weight) Then
            lblPetResult.Text = "Enter a valid pet weight."
            Return
        End If

        If Not Decimal.TryParse(txtPetDose.Text, dosePerKg) Then
            lblPetResult.Text = "Enter a valid dose per kg."
            Return
        End If

        ' Calculate total dosage
        Dim totalDose As Decimal = weight * dosePerKg

        lblPetResult.Text = $"Total Dosage: {Math.Round(totalDose, 2)} mg"
    End Sub


    Protected Sub btnPhysicsCalc_Click(sender As Object, e As EventArgs) Handles btnPhysicsCalc.Click
        Dim mass As Decimal
        Dim acceleration As Decimal

        ' Validate inputs
        If Not Decimal.TryParse(txtMass.Text, mass) Then
            lblPhysicsResult.Text = "Enter a valid mass."
            Return
        End If

        If Not Decimal.TryParse(txtAcceleration.Text, acceleration) Then
            lblPhysicsResult.Text = "Enter a valid acceleration."
            Return
        End If

        ' Calculate force
        Dim force As Decimal = mass * acceleration

        lblPhysicsResult.Text = $"Force: {Math.Round(force, 2)} N"
    End Sub

    Protected Sub btnPriceProfitCalc_Click(sender As Object, e As EventArgs) Handles btnPriceProfitCalc.Click
        Dim cost As Decimal
        Dim salePrice As Decimal

        ' Validate inputs
        If Not Decimal.TryParse(txtPriceCost.Text, cost) Then
            lblPriceProfitResult.Text = "Enter a valid cost."
            Return
        End If

        If Not Decimal.TryParse(txtPriceSale.Text, salePrice) Then
            lblPriceProfitResult.Text = "Enter a valid sale price."
            Return
        End If

        ' Calculate profit and margin
        Dim profit As Decimal = salePrice - cost
        Dim margin As Decimal = If(salePrice <> 0, (profit / salePrice) * 100, 0)

        lblPriceProfitResult.Text = $"Profit: {Math.Round(profit, 2)} | Margin: {Math.Round(margin, 2)}%"
    End Sub

    Protected Sub btnPregCalc_Click(sender As Object, e As EventArgs) Handles btnPregCalc.Click
        Dim weight As Decimal
        Dim height As Decimal
        Dim trimester As Integer

        ' Validate inputs
        If Not Decimal.TryParse(txtPregWeight.Text, weight) Then
            lblPregResult.Text = "Enter a valid pre-pregnancy weight."
            Return
        End If

        If Not Decimal.TryParse(txtPregHeight.Text, height) Then
            lblPregResult.Text = "Enter a valid height."
            Return
        End If

        If Not Integer.TryParse(txtPregTrimester.Text, trimester) OrElse trimester < 1 OrElse trimester > 3 Then
            lblPregResult.Text = "Enter a valid trimester (1, 2, or 3)."
            Return
        End If

        ' Calculate BMR using Mifflin-St Jeor Equation
        ' For simplicity, assume female:
        Dim bmr As Decimal = 10 * weight + 6.25 * height - 5 * 30 + 5 ' Age assumed 30 for default

        ' Add extra calories based on trimester
        Select Case trimester
            Case 1
                bmr += 0 ' no extra
            Case 2
                bmr += 340
            Case 3
                bmr += 450
        End Select

        lblPregResult.Text = $"Estimated Daily Calories: {Math.Round(bmr, 0)} kcal"
    End Sub


    Protected Sub btnProdCalc_Click(sender As Object, e As EventArgs) Handles btnProdCalc.Click
        Dim totalTasks As Decimal
        Dim completedTasks As Decimal

        ' Validate inputs
        If Not Decimal.TryParse(txtProdTasks.Text, totalTasks) OrElse totalTasks <= 0 Then
            lblProdResult.Text = "Enter a valid total number of tasks."
            Return
        End If

        If Not Decimal.TryParse(txtProdCompleted.Text, completedTasks) OrElse completedTasks < 0 Then
            lblProdResult.Text = "Enter a valid number of completed tasks."
            Return
        End If

        If completedTasks > totalTasks Then
            lblProdResult.Text = "Completed tasks cannot exceed total tasks."
            Return
        End If

        ' Calculate productivity percentage
        Dim productivity As Decimal = (completedTasks / totalTasks) * 100
        lblProdResult.Text = $"Productivity: {Math.Round(productivity, 2)} %"
    End Sub

    Protected Sub btnPomodoroStart_Click(sender As Object, e As EventArgs) Handles btnPomodoroStart.Click
        Dim workMinutes As Integer
        Dim breakMinutes As Integer

        ' Validate inputs
        If Not Integer.TryParse(txtPomWork.Text, workMinutes) OrElse workMinutes <= 0 Then
            lblPomResult.Text = "Enter a valid number of work minutes."
            Return
        End If

        If Not Integer.TryParse(txtPomBreak.Text, breakMinutes) OrElse breakMinutes < 0 Then
            lblPomResult.Text = "Enter a valid number of break minutes."
            Return
        End If

        ' Calculate timer end times
        Dim nowTime As DateTime = DateTime.Now
        Dim workEnd As DateTime = nowTime.AddMinutes(workMinutes)
        Dim breakEnd As DateTime = workEnd.AddMinutes(breakMinutes)

        lblPomResult.Text = $"Work session ends at {workEnd:hh:mm tt}. Break ends at {breakEnd:hh:mm tt}."
    End Sub

    Protected Sub btnQuadCalc_Click(sender As Object, e As EventArgs) Handles btnQuadCalc.Click
        Dim a, b, c As Double

        ' Validate inputs
        If Not Double.TryParse(txtQuadA.Text, a) Then
            lblQuadResult.Text = "Enter a valid number for a."
            Return
        End If
        If Not Double.TryParse(txtQuadB.Text, b) Then
            lblQuadResult.Text = "Enter a valid number for b."
            Return
        End If
        If Not Double.TryParse(txtQuadC.Text, c) Then
            lblQuadResult.Text = "Enter a valid number for c."
            Return
        End If

        If a = 0 Then
            lblQuadResult.Text = "Coefficient 'a' cannot be 0."
            Return
        End If

        ' Calculate discriminant
        Dim discriminant As Double = b * b - 4 * a * c
        Dim result As String = ""

        If discriminant > 0 Then
            Dim root1 As Double = (-b + Math.Sqrt(discriminant)) / (2 * a)
            Dim root2 As Double = (-b - Math.Sqrt(discriminant)) / (2 * a)
            result = $"Two real roots: {root1:F2} and {root2:F2}"
        ElseIf discriminant = 0 Then
            Dim root As Double = -b / (2 * a)
            result = $"One real root: {root:F2}"
        Else
            Dim realPart As Double = -b / (2 * a)
            Dim imagPart As Double = Math.Sqrt(-discriminant) / (2 * a)
            result = $"Two complex roots: {realPart:F2} ± {imagPart:F2}i"
        End If

        lblQuadResult.Text = result
    End Sub

    Protected Sub btnRetCalc_Click(sender As Object, e As EventArgs) Handles btnRetCalc.Click
        Dim currentSavings, monthlyContribution, years As Double

        ' Validate inputs
        If Not Double.TryParse(txtRetSavings.Text, currentSavings) Then
            lblRetResult.Text = "Enter a valid number for Current Savings."
            Return
        End If
        If Not Double.TryParse(txtRetContribution.Text, monthlyContribution) Then
            lblRetResult.Text = "Enter a valid number for Monthly Contribution."
            Return
        End If
        If Not Double.TryParse(txtRetYears.Text, years) Then
            lblRetResult.Text = "Enter a valid number for Years to Retirement."
            Return
        End If

        If years <= 0 Then
            lblRetResult.Text = "Years to Retirement must be greater than 0."
            Return
        End If

        ' Assume an average annual return (can be adjusted)
        Dim annualReturnRate As Double = 0.07 ' 7% average annual return
        Dim monthlyRate As Double = annualReturnRate / 12
        Dim totalMonths As Double = years * 12

        ' Future value formula: FV = P*(1+r)^n + PMT*(((1+r)^n - 1)/r)
        Dim futureValue As Double = currentSavings * Math.Pow(1 + monthlyRate, totalMonths) +
                                monthlyContribution * ((Math.Pow(1 + monthlyRate, totalMonths) - 1) / monthlyRate)

        lblRetResult.Text = $"Estimated Retirement Savings: {futureValue:C2}"
    End Sub


    Protected Sub btnROICalc_Click(sender As Object, e As EventArgs) Handles btnROICalc.Click
        Dim initialInvestment, finalValue As Double

        ' Validate inputs
        If Not Double.TryParse(txtROIInit.Text, initialInvestment) Then
            lblROIResult.Text = "Enter a valid number for Initial Investment."
            Return
        End If
        If Not Double.TryParse(txtROIFinalVal.Text, finalValue) Then
            lblROIResult.Text = "Enter a valid number for Final Value."
            Return
        End If

        If initialInvestment = 0 Then
            lblROIResult.Text = "Initial Investment cannot be zero."
            Return
        End If

        ' ROI calculation
        Dim roi As Double = ((finalValue - initialInvestment) / initialInvestment) * 100

        lblROIResult.Text = $"Return on Investment (ROI): {roi:F2}%"
    End Sub

    Protected Sub btnGoalAmountCalc_Click(sender As Object, e As EventArgs) Handles btnGoalAmountCalc.Click
        Dim goalAmount, monthlySavings As Double

        ' Validate inputs
        If Not Double.TryParse(txtGoalAmount.Text, goalAmount) Then
            lblGoalAmountResult.Text = "Enter a valid number for Goal Amount."
            Return
        End If
        If Not Double.TryParse(txtGoalMonthly.Text, monthlySavings) Then
            lblGoalAmountResult.Text = "Enter a valid number for Monthly Savings."
            Return
        End If

        If monthlySavings <= 0 Then
            lblGoalAmountResult.Text = "Monthly Savings must be greater than zero."
            Return
        End If

        ' Calculate months needed
        Dim monthsNeeded As Double = goalAmount / monthlySavings
        lblGoalAmountResult.Text = $"Months Needed to Reach Goal: {Math.Ceiling(monthsNeeded)}"
    End Sub

    Protected Sub btnSleepCalc_Click(sender As Object, e As EventArgs) Handles btnSleepCalc.Click
        Dim age As Integer

        ' Validate input
        If Not Integer.TryParse(txtSleepAge.Text, age) Then
            lblSleepResult.Text = "Enter a valid number for Age."
            Return
        End If

        Dim sleepHours As Double

        ' Determine recommended sleep based on age
        Select Case age
            Case 0 To 2
                sleepHours = 11 ' Average for toddlers
            Case 3 To 5
                sleepHours = 10
            Case 6 To 13
                sleepHours = 9
            Case 14 To 17
                sleepHours = 8
            Case 18 To 64
                sleepHours = 7
            Case Is >= 65
                sleepHours = 7
            Case Else
                sleepHours = 7
        End Select

        lblSleepResult.Text = $"Recommended Sleep: {sleepHours} hours per day."
    End Sub

    Protected Sub btnStockCalc_Click(sender As Object, e As EventArgs) Handles btnStockCalc.Click
        Dim initialInvestment As Double
        Dim finalValue As Double

        ' Validate inputs
        If Not Double.TryParse(txtStockInit.Text, initialInvestment) Then
            lblStockResult.Text = "Enter a valid number for Initial Investment."
            Return
        End If

        If Not Double.TryParse(txtStockFinal.Text, finalValue) Then
            lblStockResult.Text = "Enter a valid number for Final Value."
            Return
        End If

        If initialInvestment = 0 Then
            lblStockResult.Text = "Initial Investment cannot be zero."
            Return
        End If

        ' Calculate ROI
        Dim roi As Double = ((finalValue - initialInvestment) / initialInvestment) * 100

        lblStockResult.Text = $"Return on Investment (ROI): {roi:F2}%"
    End Sub

    Protected Sub btnStudyCalc_Click(sender As Object, e As EventArgs) Handles btnStudyCalc.Click
        Dim totalHours As Double
        Dim subjects As Integer

        ' Validate inputs
        If Not Double.TryParse(txtStudyTotalHours.Text, totalHours) Then
            lblStudyResult.Text = "Enter a valid number for Total Hours."
            Return
        End If

        If Not Integer.TryParse(txtStudySubjects.Text, subjects) Then
            lblStudyResult.Text = "Enter a valid number for Subjects."
            Return
        End If

        If subjects <= 0 Then
            lblStudyResult.Text = "Number of subjects must be greater than zero."
            Return
        End If

        ' Calculate time per subject
        Dim hoursPerSubject As Double = totalHours / subjects

        lblStudyResult.Text = $"You should spend approximately {hoursPerSubject:F2} hours per subject."
    End Sub

    Protected Sub btnTDEECalc_Click(sender As Object, e As EventArgs) Handles btnTDEECalc.Click
        Dim weight As Double
        Dim height As Double
        Dim age As Integer
        Dim activity As Double
        Dim tdee As Double
        Dim gender As String = txtTDEEGender.Text.Trim().ToUpper()

        ' Input validation
        If Not Double.TryParse(txtTDEEWeight.Text, weight) Then
            lblTDEResult.Text = "Enter a valid weight."
            Return
        End If

        If Not Double.TryParse(txtTDEEHeight.Text, height) Then
            lblTDEResult.Text = "Enter a valid height."
            Return
        End If

        If Not Integer.TryParse(txtTDEEAge.Text, age) Then
            lblTDEResult.Text = "Enter a valid age."
            Return
        End If

        If Not Double.TryParse(txtTDEEActivity.Text, activity) OrElse activity < 1 OrElse activity > 5 Then
            lblTDEResult.Text = "Enter a valid activity level (1-5)."
            Return
        End If

        ' BMR calculation (Mifflin-St Jeor)
        Dim bmr As Double
        If gender = "M" Then
            bmr = 10 * weight + 6.25 * height - 5 * age + 5
        ElseIf gender = "F" Then
            bmr = 10 * weight + 6.25 * height - 5 * age - 161
        Else
            lblTDEResult.Text = "Enter gender as M or F."
            Return
        End If

        ' Activity multiplier
        Dim activityMultiplier As Double
        Select Case activity
            Case 1
                activityMultiplier = 1.2
            Case 2
                activityMultiplier = 1.375
            Case 3
                activityMultiplier = 1.55
            Case 4
                activityMultiplier = 1.725
            Case 5
                activityMultiplier = 1.9
            Case Else
                activityMultiplier = 1.2
        End Select

        tdee = bmr * activityMultiplier
        lblTDEResult.Text = $"Your estimated TDEE is {tdee:F0} calories/day."
    End Sub

    Protected Sub btnTravelCalc_Click(sender As Object, e As EventArgs) Handles btnTravelCalc.Click
        Dim distance As Double
        Dim efficiency As Double
        Dim fuelPrice As Double
        Dim totalCost As Double

        ' Input validation
        If Not Double.TryParse(txtTravelDistance.Text, distance) OrElse distance <= 0 Then
            lblTravelResult.Text = "Enter a valid distance."
            Return
        End If

        If Not Double.TryParse(txtTravelEfficiency.Text, efficiency) OrElse efficiency <= 0 Then
            lblTravelResult.Text = "Enter a valid fuel efficiency."
            Return
        End If

        If Not Double.TryParse(txtTravelFuelPrice.Text, fuelPrice) OrElse fuelPrice < 0 Then
            lblTravelResult.Text = "Enter a valid fuel price."
            Return
        End If

        ' Calculate total fuel cost
        totalCost = (distance / efficiency) * fuelPrice

        lblTravelResult.Text = $"Estimated fuel cost: {totalCost:F2} currency units."
    End Sub

    Protected Sub btnUnitConvert_Click(sender As Object, e As EventArgs) Handles btnUnitConvert.Click
        Dim value As Double
        Dim fromUnit As String = txtUnitFrom.Text.Trim().ToLower()
        Dim toUnit As String = txtUnitTo.Text.Trim().ToLower()
        Dim result As Double

        ' Validate numeric input
        If Not Double.TryParse(txtUnitValue.Text, value) Then
            lblUnitResult.Text = "Enter a valid numeric value."
            Return
        End If

        ' Simple conversion logic (extendable)
        Try
            Select Case fromUnit
                Case "m", "meter", "meters"
                    Select Case toUnit
                        Case "cm"
                            result = value * 100
                        Case "mm"
                            result = value * 1000
                        Case "km"
                            result = value / 1000
                        Case "ft"
                            result = value * 3.28084
                        Case Else
                            lblUnitResult.Text = "Unsupported target unit."
                            Return
                    End Select

                Case "kg", "kilogram", "kilograms"
                    Select Case toUnit
                        Case "g"
                            result = value * 1000
                        Case "lb", "lbs", "pound", "pounds"
                            result = value * 2.20462
                        Case Else
                            lblUnitResult.Text = "Unsupported target unit."
                            Return
                    End Select

                Case "l", "liter", "liters"
                    Select Case toUnit
                        Case "ml"
                            result = value * 1000
                        Case "gal", "gallon", "gallons"
                            result = value * 0.264172
                        Case Else
                            lblUnitResult.Text = "Unsupported target unit."
                            Return
                    End Select

                Case Else
                    lblUnitResult.Text = "Unsupported source unit."
                    Return
            End Select

            lblUnitResult.Text = $"{value} {fromUnit} = {result:F4} {toUnit}"

        Catch ex As Exception
            lblUnitResult.Text = "Conversion failed: " & ex.Message
        End Try
    End Sub

    Protected Sub btnVATCalc_Click(sender As Object, e As EventArgs) Handles btnVATCalc.Click
        Dim price As Double
        Dim taxRate As Double

        ' Validate numeric inputs
        If Not Double.TryParse(txtVATPrice.Text, price) Then
            lblVATResult.Text = "Enter a valid numeric price."
            Return
        End If

        If Not Double.TryParse(txtVATRate.Text, taxRate) Then
            lblVATResult.Text = "Enter a valid numeric tax rate."
            Return
        End If

        ' Calculate tax amount and total price
        Dim taxAmount As Double = price * taxRate / 100
        Dim totalPrice As Double = price + taxAmount

        ' Display result
        lblVATResult.Text = $"Price: {price:C2} | Tax ({taxRate}%): {taxAmount:C2} | Total: {totalPrice:C2}"
    End Sub

    Protected Sub btnWaterCalc_Click(sender As Object, e As EventArgs) Handles btnWaterCalc.Click
        Dim weight As Double

        ' Validate numeric input
        If Not Double.TryParse(txtWaterWeight.Text, weight) Then
            lblWaterResult.Text = "Enter a valid numeric weight."
            Return
        End If

        ' Calculate daily water intake in liters
        ' Common recommendation: 35 ml per kg body weight
        Dim waterLiters As Double = weight * 0.035

        ' Display result
        lblWaterResult.Text = $"Recommended daily water intake: {waterLiters:F2} liters"
    End Sub

    Protected Sub btnChemCalc_Click(sender As Object, e As EventArgs) Handles btnChemCalc.Click
        Dim moles As Double
        Dim volume As Double

        ' Validate numeric inputs
        If Not Double.TryParse(txtChemMoles.Text, moles) Then
            lblChemResult.Text = "Enter a valid numeric value for moles."
            Return
        End If

        If Not Double.TryParse(txtChemVolume.Text, volume) OrElse volume = 0 Then
            lblChemResult.Text = "Enter a valid non-zero volume in liters."
            Return
        End If

        ' Calculate molarity: M = moles / volume
        Dim molarity As Double = moles / volume

        ' Display result
        lblChemResult.Text = $"Molarity: {molarity:F3} M"
    End Sub

    Protected Sub btnBSACalc_Click(sender As Object, e As EventArgs) Handles btnBSACalc.Click
        Dim weight As Double
        Dim height As Double

        ' Validate inputs
        If Not Double.TryParse(txtBSAWeight.Text, weight) OrElse weight <= 0 Then
            lblBSAResult.Text = "Enter a valid positive weight in kg."
            Return
        End If

        If Not Double.TryParse(txtBSAHeight.Text, height) OrElse height <= 0 Then
            lblBSAResult.Text = "Enter a valid positive height in cm."
            Return
        End If

        ' Mosteller formula: BSA (m²) = sqrt((height*weight)/3600)
        Dim bsa As Double = Math.Sqrt((height * weight) / 3600)

        ' Display result
        lblBSAResult.Text = $"Body Surface Area: {bsa:F2} m²"
    End Sub


End Class
