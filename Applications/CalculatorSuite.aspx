<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CalculatorSuite.aspx.vb" Inherits="WebApplication1.CalculatorSuite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container my-4">

        <!-- Calculator Selector Dropdown (searchable) -->
        <div class="mb-4">
            <label class="form-label fw-bold">Select Calculator:</label>
            <asp:DropDownList ID="ddlCalculators" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlCalculators_SelectedIndexChanged">
            </asp:DropDownList>
        </div>

        <!-- Title / Description for Print -->
        <div class="mb-3 d-flex flex-column flex-md-row align-items-start justify-content-between gap-2">
            <div class="flex-grow-1">
                <asp:TextBox ID="txtCalcTitle" runat="server" CssClass="form-control mb-2" Placeholder="Enter title for your calculation..." />
                <asp:TextBox ID="txtCalcDesc" runat="server" TextMode="MultiLine" CssClass="form-control" Placeholder="Optional description..." Rows="2" />
            </div>
            <div class="d-flex align-items-start gap-2">
                <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-success mt-md-2" UseSubmitBehavior="false" Text="Print / Save PDF" OnClientClick="return printCalculator();" />
            </div>
        </div>

        <!-- Dynamic Calculator Display -->
<asp:MultiView ID="mvCalculators" runat="server" ActiveViewIndex="0">

    <!-- Advanced Algebra Solver -->
    <asp:View ID="viewAlgebraAdvanced" runat="server">
        <asp:Panel ID="pnlAlgebra" runat="server">

            <div class="card shadow-sm mb-4 p-4">
                <h4>Algebra Solver</h4>
                <p>Evaluate expressions or solve for x (e.g., 2*x + 5 = 15)</p>

                <div class="mb-3">
                    <label>Enter Expression or Equation:</label>
                    <asp:TextBox ID="txtAlgExpression" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3 d-flex gap-2">
                    <asp:Button ID="btnAlgEval" runat="server" Text="Evaluate / Solve" CssClass="btn btn-primary btn-sm" OnClick="btnAlgEval_Click" />
                    <asp:Button ID="btnAlgClear" runat="server" Text="Clear History" CssClass="btn btn-secondary btn-sm" OnClick="btnAlgClear_Click" />
                </div>

                <div class="mb-3 mt-2">
                    <asp:Label ID="lblAlgResult" runat="server" CssClass="fw-bold"></asp:Label>
                </div>

                <div class="mb-3">
                    <label>History:</label>
                    <div id="divAlgHistory" runat="server" class="history-box"></div>
                    <%--<asp:TextBox ID="txtAlgHistory" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="6" ReadOnly="True"></asp:TextBox>--%>
                </div>
            </div>

            </asp:Panel>
    </asp:View>

    <!-- 2. Advanced BMI / Body Fat Calculator (Metric & Imperial) -->
    <asp:View ID="viewBMI" runat="server">
        <asp:Panel ID="pnlBMI" runat="server">
            <div class="card shadow-sm mb-4 p-4">
                <h4>BMI / Body Fat Calculator</h4>
                <p>Enter your weight, height, age, and gender to calculate BMI, estimated body fat, and healthy weight range.</p>

                <div class="row mb-3">
                    <div class="col-md-4">
                        <label>Weight:</label>
                        <div class="input-group">
                            <asp:TextBox ID="txtBMIWeight" runat="server" CssClass="form-control" />
                            <asp:DropDownList ID="ddlBMIWeightUnit" runat="server" CssClass="form-select">
                                <asp:ListItem Text="kg" Value="kg" />
                                <asp:ListItem Text="lb" Value="lb" />
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <label>Height:</label>
                        <div class="input-group">
                            <asp:TextBox ID="txtBMIHeight" runat="server" CssClass="form-control" />
                            <asp:DropDownList ID="ddlBMIHeightUnit" runat="server" CssClass="form-select">
                                <asp:ListItem Text="cm" Value="cm" />
                                <asp:ListItem Text="in" Value="in" />
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <label>Age (years):</label>
                        <asp:TextBox ID="txtBMIAge" runat="server" CssClass="form-control" />
                    </div>
                </div>

                <div class="mb-3">
                    <label>Gender:</label>
                    <asp:DropDownList ID="ddlBMIGender" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Male" Value="M" />
                        <asp:ListItem Text="Female" Value="F" />
                    </asp:DropDownList>
                </div>

                <div class="mb-3">
                    <asp:Button ID="btnBMICalc" runat="server" Text="Calculate" CssClass="btn btn-primary" OnClick="btnBMICalc_Click" />
                </div>

                <div class="mb-3 mt-2">
                    <asp:Label ID="lblBMIResult" runat="server" CssClass="fw-bold" />
                </div>

                <div class="mb-3">
                    <label>History:</label>
                    <div id="divBMIHistory" runat="server" class="history-box"></div>

                    <%--<asp:TextBox ID="txtBMIHistory" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="6" ReadOnly="True" Wrap="False" />--%>
                </div>
            </div>
        </asp:Panel>
    </asp:View>
    
    <!-- 3. BMR / TDEE Calculator -->
    <asp:View ID="viewBMR" runat="server">
        <asp:Panel ID="pnlBMR" runat="server">
            <div class="card shadow-sm mb-4 p-4">
                <h4>BMR / TDEE Calculator</h4>

                <!-- Weight, Height, Age row -->
                <div class="row mb-3">
                    <!-- Weight -->
                    <div class="col-md-4">
                        <label>Weight:</label>
                        <div class="input-group">
                            <asp:TextBox ID="txtBMRWeight" runat="server" CssClass="form-control" />
                            <asp:DropDownList ID="ddlBMRWeightUnit" runat="server" CssClass="form-select">
                                <asp:ListItem Value="kg" Selected="True">kg</asp:ListItem>
                                <asp:ListItem Value="lb">lb</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <!-- Height -->
                    <div class="col-md-4">
                        <label>Height:</label>
                        <div class="input-group">
                            <asp:TextBox ID="txtBMRHeight" runat="server" CssClass="form-control" />
                            <asp:DropDownList ID="ddlBMRHeightUnit" runat="server" CssClass="form-select">
                                <asp:ListItem Value="cm" Selected="True">cm</asp:ListItem>
                                <asp:ListItem Value="in">in</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <!-- Age -->
                    <div class="col-md-4">
                        <label>Age:</label>
                        <asp:TextBox ID="txtBMRAge" runat="server" CssClass="form-control" />
                    </div>
                </div>

                <!-- Gender and Activity row -->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <label>Gender:</label>
                        <asp:DropDownList ID="ddlBMRGender" runat="server" CssClass="form-select">
                            <asp:ListItem Value="M" Selected="True">Male</asp:ListItem>
                            <asp:ListItem Value="F">Female</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-6">
                        <label>Activity Level (for TDEE):</label>
                        <asp:DropDownList ID="ddlBMRActivity" runat="server" CssClass="form-select">
                            <asp:ListItem Value="1.2" Selected="True">Sedentary (little/no exercise)</asp:ListItem>
                            <asp:ListItem Value="1.375">Lightly active (light exercise 1-3 days/wk)</asp:ListItem>
                            <asp:ListItem Value="1.55">Moderately active (moderate exercise 3-5 days/wk)</asp:ListItem>
                            <asp:ListItem Value="1.725">Very active (hard exercise 6-7 days/wk)</asp:ListItem>
                            <asp:ListItem Value="1.9">Extra active (very hard exercise or physical job)</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <!-- Button -->
                <div class="mb-3">
                    <asp:Button ID="btnBMRCalc" runat="server" Text="Calculate BMR / TDEE" CssClass="btn btn-primary" OnClick="btnBMRCalc_Click" />
                </div>

                <!-- Result -->
                <div class="mb-3 mt-2">
                    <asp:Label ID="lblBMRResult" runat="server" CssClass="fw-bold"></asp:Label>
                </div>

                <!-- History -->
                <div class="mb-3">
                    <label>History:</label>
                    <div id="divBMRHistory" runat="server" class="history-box" style="height:auto; min-height:100px; overflow:auto; white-space:pre-wrap;"></div>
                </div>
            </div>
        </asp:Panel>
    </asp:View>



    <!-- 4. Break-even Calculator -->
    <asp:View ID="viewBreakEven" runat="server">
        <asp:Panel ID="pnlBreakEven" runat="server">
            <div class="card shadow-sm mb-4 p-4">
                <h4>Break-even Calculator</h4>

                <!-- Row 1: Fixed Costs, Price per Unit, Variable Cost per Unit -->
                <div class="row mb-3">
                    <!-- Fixed Costs -->
                    <div class="col-md-4">
                        <label>Fixed Costs ($):</label>
                        <asp:TextBox ID="txtBreakEvenFixed" runat="server" CssClass="form-control" />
                    </div>

                    <!-- Price per Unit -->
                    <div class="col-md-4">
                        <label>Price per Unit ($):</label>
                        <asp:TextBox ID="txtBreakEvenPrice" runat="server" CssClass="form-control" />
                    </div>

                    <!-- Variable Cost per Unit -->
                    <div class="col-md-4">
                        <label>Variable Cost per Unit ($):</label>
                        <asp:TextBox ID="txtBreakEvenVariable" runat="server" CssClass="form-control" />
                    </div>
                </div>

                <!-- Row 2: Target Profit -->
                <div class="row mb-3">
                    <div class="col-md-4">
                        <label>Optional Target Profit ($):</label>
                        <asp:TextBox ID="txtBreakEvenTargetProfit" runat="server" CssClass="form-control" Placeholder="Optional" />
                    </div>
                </div>

                <!-- Calculate Button -->
                <div class="mb-3">
                    <asp:Button ID="btnBreakEvenCalc" runat="server" Text="Calculate" CssClass="btn btn-primary" OnClick="btnBreakEvenCalc_Click" />
                </div>

                <!-- Result -->
                <div class="mb-3 mt-2">
                    <asp:Label ID="lblBreakEvenResult" runat="server" CssClass="fw-bold"></asp:Label>
                </div>

                <!-- History -->
                <div class="mb-3">
                    <label>Calculation History:</label>
                    <div id="divBreakEvenHistory" runat="server" class="history-box" style="height:auto; min-height:100px; overflow:auto; white-space:pre-wrap;"></div>
                </div>
            </div>
        </asp:Panel>
    </asp:View>


    <!-- 5. Caloric Intake Calculator -->
    <asp:View ID="viewCalorieIntake" runat="server">
        <asp:Panel ID="pnlCalorie" runat="server">
            <div class="card shadow-sm mb-4 p-4">
                <h4>Calorie Intake Calculator</h4>

                <!-- Row 1: Weight + Height + Age + Gender -->
                <div class="row mb-3">
                    <div class="col-md-3">
                        <label>Weight:</label>
                        <div class="input-group">
                            <asp:TextBox ID="txtCalorieWeight" runat="server" CssClass="form-control" />
                            <asp:DropDownList ID="ddlCalorieWeightUnit" runat="server" CssClass="form-select">
                                <asp:ListItem Value="kg" Selected="True">kg</asp:ListItem>
                                <asp:ListItem Value="lb">lb</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <label>Height:</label>
                        <div class="input-group">
                            <asp:TextBox ID="txtCalorieHeight" runat="server" CssClass="form-control" />
                            <asp:DropDownList ID="ddlCalorieHeightUnit" runat="server" CssClass="form-select">
                                <asp:ListItem Value="cm" Selected="True">cm</asp:ListItem>
                                <asp:ListItem Value="in">in</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <label>Age:</label>
                        <asp:TextBox ID="txtCalorieAge" runat="server" CssClass="form-control" />
                    </div>

                    <div class="col-md-3">
                        <label>Gender:</label>
                        <asp:DropDownList ID="ddlCalorieGender" runat="server" CssClass="form-select">
                            <asp:ListItem Value="M" Selected="True">Male</asp:ListItem>
                            <asp:ListItem Value="F">Female</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <!-- Row 2: Activity Level + Fitness Goal -->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <label>Activity Level:</label>
                        <asp:DropDownList ID="ddlCalorieActivity" runat="server" CssClass="form-select">
                            <asp:ListItem Value="1.2" Selected="True">Sedentary (Little or no exercise)</asp:ListItem>
                            <asp:ListItem Value="1.375">Lightly Active (Light exercise/sports 1–3 days/week)</asp:ListItem>
                            <asp:ListItem Value="1.55">Moderately Active (Moderate exercise 3–5 days/week)</asp:ListItem>
                            <asp:ListItem Value="1.725">Very Active (Hard exercise 6–7 days/week)</asp:ListItem>
                            <asp:ListItem Value="1.9">Extremely Active (Very hard daily exercise or physical job)</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-md-6">
                        <label>Fitness Goal:</label>
                        <asp:DropDownList ID="ddlFitnessGoal" runat="server" CssClass="form-select">
                            <asp:ListItem Value="lose_standard" Selected="True">Lose Weight</asp:ListItem>
                            <asp:ListItem Value="lose_aggressive">Lose Weight (Aggressive)</asp:ListItem>
                            <asp:ListItem Value="maintain">Maintain</asp:ListItem>
                            <asp:ListItem Value="gain_lean">Gain Lean</asp:ListItem>
                            <asp:ListItem Value="gain_bulk">Gain Bulk</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <!-- Button -->
                <div class="mb-3">
                    <asp:Button ID="btnCalorieCalc" runat="server" Text="Calculate" CssClass="btn btn-primary" OnClick="btnCalorieCalc_Click" />
                </div>

                <!-- Result -->
                <div class="mb-3 mt-2">
                    <asp:Label ID="lblCalorieResult" runat="server" CssClass="fw-bold"></asp:Label>
                </div>

                <!-- Macro Bar Chart -->
                <div class="mb-3">
                    <label>Macro Breakdown:</label>
                    <div class="progress" style="height:25px;">
                        <div id="divProteinBar" runat="server" class="progress-bar bg-success" role="progressbar" style="width:0%">Protein</div>
                        <div id="divCarbBar" runat="server" class="progress-bar bg-info" role="progressbar" style="width:0%">Carbs</div>
                        <div id="divFatBar" runat="server" class="progress-bar bg-warning" role="progressbar" style="width:0%">Fat</div>
                    </div>
                </div>

                <!-- History -->
                <div class="mb-3">
                    <label>Calculation History:</label>
                    <div id="divCalorieHistory" runat="server" class="history-box" style="height:auto; min-height:100px; overflow:auto; white-space:pre-wrap;"></div>
                </div>
            </div>
        </asp:Panel>
    </asp:View>

    <!-- 6. Car Loan Calculator -->
    <asp:View ID="viewCarLoan" runat="server">
        <asp:Panel ID="pnlCarLoan" runat="server">
            <div class="card shadow-sm mb-4 p-4">
                <h4>Car Loan Calculator</h4>

                <!-- Row 1: Loan Amount + Interest Rate + Term (Months) -->
                <div class="row mb-3">
                    <div class="col-md-3">
                        <label>Loan Amount:</label>
                        <asp:TextBox ID="txtCarLoanAmount" runat="server" CssClass="form-control" />
                    </div>

                    <div class="col-md-3">
                        <label>Interest Rate (% per year):</label>
                        <asp:TextBox ID="txtCarLoanRate" runat="server" CssClass="form-control" />
                    </div>

                    <div class="col-md-3">
                        <label>Term (Months):</label>
                        <asp:TextBox ID="txtCarLoanMonths" runat="server" CssClass="form-control" />
                    </div>

                    <div class="col-md-3">
                        <label>Extra Monthly Payment (Optional):</label>
                        <asp:TextBox ID="txtCarLoanExtra" runat="server" CssClass="form-control" />
                    </div>
                </div>

                <!-- Calculate Button -->
                <div class="mb-3">
                    <asp:Button ID="btnCarLoanCalc" runat="server" Text="Calculate" CssClass="btn btn-primary" OnClick="btnCarLoanCalc_Click" />
                </div>

                <!-- Result -->
                <div class="mb-3 mt-2">
                    <asp:Label ID="lblCarLoanResult" runat="server" CssClass="fw-bold"></asp:Label>
                </div>

                <!-- Amortization Table -->
                <div class="mb-3">
                    <label>Amortization Breakdown:</label>
                    <div id="divCarLoanAmortization" runat="server" class="history-box" style="height:auto; max-height:200px; overflow:auto; white-space:pre-wrap;"></div>
                </div>

                <!-- Calculation History -->
                <div class="mb-3">
                    <label>Calculation History:</label>
                    <div id="divCarLoanHistory" runat="server" class="history-box" style="height:auto; min-height:100px; overflow:auto; white-space:pre-wrap;"></div>
                </div>
            </div>
        </asp:Panel>
    </asp:View>


    <!-- 7. Chemistry Molarity Calculator -->
    <asp:View ID="viewChemistryMolarity" runat="server">
        <asp:Panel ID="pnlMolarity" runat="server">
            <div class="card shadow-sm mb-4 p-4">
                <h4>Chemistry Molarity Calculator</h4>

                <!-- Row 1: Mass / Moles + Molar Mass -->
                <div class="row mb-3">
                    <div class="col-md-4">
                        <label>Amount of solute:</label>
                        <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" />
                    </div>
                    <div class="col-md-4">
                        <label>Unit:</label>
                        <asp:DropDownList ID="ddlAmountUnit" runat="server" CssClass="form-select">
                            <asp:ListItem Value="moles" Selected="True">Moles</asp:ListItem>
                            <asp:ListItem Value="grams">Grams</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        <label>Molar Mass (g/mol, required if grams):</label>
                        <asp:TextBox ID="txtMolarMass" runat="server" CssClass="form-control" />
                    </div>
                </div>

                <!-- Row 2: Volume -->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <label>Volume of solution:</label>
                        <asp:TextBox ID="txtVolume" runat="server" CssClass="form-control" />
                    </div>
                    <div class="col-md-6">
                        <label>Volume unit:</label>
                        <asp:DropDownList ID="ddlVolumeUnit" runat="server" CssClass="form-select">
                            <asp:ListItem Value="L" Selected="True">Liters (L)</asp:ListItem>
                            <asp:ListItem Value="mL">Milliliters (mL)</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <!-- Calculate Button -->
                <div class="mb-3">
                    <asp:Button ID="btnMolarityCalc" runat="server" Text="Calculate" CssClass="btn btn-primary" OnClick="btnMolarityCalc_Click" />
                </div>

                <!-- Result -->
                <div class="mb-3 mt-2">
                    <asp:Label ID="lblMolarityResult" runat="server" CssClass="fw-bold"></asp:Label>
                </div>

                <!-- Calculation History -->
                <div class="mb-3">
                    <label>Calculation History:</label>
                    <div id="divMolarityHistory" runat="server" class="history-box" style="height:auto; min-height:100px; overflow:auto; white-space:pre-wrap;"></div>
                </div>
            </div>
        </asp:Panel>
    </asp:View>



    <!-- 8. Compound Interest Calculator -->
    <asp:View ID="viewCompoundInterest" runat="server">
        <asp:Panel ID="pnlCompoundInterest" runat="server">
            <div class="card shadow-sm mb-4 p-4">
                <h4>Compound Interest Calculator</h4>

                <!-- Row 1: Principal + Rate + Years -->
                <div class="row mb-3">
                    <div class="col-md-4">
                        <label>Principal:</label>
                        <asp:TextBox ID="txtCIPrincipal" runat="server" CssClass="form-control" />
                    </div>
                    <div class="col-md-4">
                        <label>Annual Interest Rate (%):</label>
                        <asp:TextBox ID="txtCIRate" runat="server" CssClass="form-control" />
                    </div>
                    <div class="col-md-4">
                        <label>Years:</label>
                        <asp:TextBox ID="txtCIYears" runat="server" CssClass="form-control" />
                    </div>
                </div>

                <!-- Row 2: Compounds + Extra Contribution + Frequency -->
                <div class="row mb-3">
                    <div class="col-md-4">
                        <label>Compounds per Year:</label>
                        <asp:TextBox ID="txtCICompounds" runat="server" CssClass="form-control" Text="12" />
                    </div>
                    <div class="col-md-4">
                        <label>Extra Contribution per Period:</label>
                        <asp:TextBox ID="txtCIExtra" runat="server" CssClass="form-control" Text="0" />
                    </div>
                    <div class="col-md-4">
                        <label>Contribution Frequency:</label>
                        <asp:DropDownList ID="ddlCIExtraFreq" runat="server" CssClass="form-select">
                            <asp:ListItem Value="monthly" Selected="True">Monthly</asp:ListItem>
                            <asp:ListItem Value="quarterly">Quarterly</asp:ListItem>
                            <asp:ListItem Value="annually">Annually</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <!-- Button -->
                <div class="mb-3">
                    <asp:Button ID="btnCICalc" runat="server" Text="Calculate" CssClass="btn btn-primary" OnClick="btnCICalc_Click" />
                </div>

                <!-- Result -->
                <div class="mb-3 mt-2">
                    <asp:Label ID="lblCIResult" runat="server" CssClass="fw-bold"></asp:Label>
                </div>

                <!-- History -->
                <div class="mb-3">
                    <label>Calculation History:</label>
                    <div id="divCIHistory" runat="server" class="history-box" style="height:auto; min-height:100px; overflow:auto; white-space:pre-wrap;"></div>
                </div>
            </div>
        </asp:Panel>
    </asp:View>




    <!-- 9. Cryptocurrency ROI Calculator -->
    <asp:View ID="viewCryptoROI" runat="server">
        <asp:Panel ID="pnlCrypto" runat="server">
            <div class="card shadow-sm mb-4 p-4">
                <h4>Advanced Cryptocurrency ROI Calculator</h4>

                <!-- Row 1: Investment Inputs -->
                <div class="row mb-3">
                    <div class="col-md-3">
                        <label>Initial Investment ($):</label>
                        <asp:TextBox ID="txtCryptoInvestment" runat="server" CssClass="form-control" />
                    </div>
                    <div class="col-md-3">
                        <label>Final Value ($):</label>
                        <asp:TextBox ID="txtCryptoFinal" runat="server" CssClass="form-control" />
                    </div>
                    <div class="col-md-3">
                        <label>Investment Period (Years):</label>
                        <asp:TextBox ID="txtCryptoYears" runat="server" CssClass="form-control" />
                    </div>
                    <div class="col-md-3">
                        <label>Extra Contribution per Period ($):</label>
                        <asp:TextBox ID="txtCryptoContribution" runat="server" CssClass="form-control" Text="0" />
                    </div>
                </div>

                <!-- Row 2: Contribution Frequency -->
                <div class="row mb-3">
                    <div class="col-md-3">
                        <label>Contribution Frequency:</label>
                        <asp:DropDownList ID="ddlCryptoFreq" runat="server" CssClass="form-select">
                            <asp:ListItem Value="1" Selected="True">Monthly</asp:ListItem>
                            <asp:ListItem Value="3">Quarterly</asp:ListItem>
                            <asp:ListItem Value="12">Yearly</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <!-- Button -->
                <div class="mb-3">
                    <asp:Button ID="btnCryptoCalc" runat="server" Text="Calculate ROI" CssClass="btn btn-primary" OnClick="btnCryptoCalc_Click" />
                </div>

                <!-- Result -->
                <div class="mb-3 mt-2">
                    <asp:Label ID="lblCryptoResult" runat="server" CssClass="fw-bold"></asp:Label>
                </div>

                <!-- History -->
                <div class="mb-3">
                    <label>Calculation History:</label>
                    <div id="divCryptoHistory" runat="server" class="history-box" style="height:auto; min-height:100px; overflow:auto; white-space:pre-wrap;"></div>
                </div>
            </div>
        </asp:Panel>
    </asp:View>




    <!-- 10. Currency Converter -->
    <asp:View ID="viewCurrencyConverter" runat="server">
    <asp:Panel ID="pnlCurrency" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Advanced Currency Converter</h4>

            <!-- Row 1: Amount + Rate -->
            <div class="row mb-3">
                <div class="col-md-6">
                    <label>Amount:</label>
                    <asp:TextBox ID="txtCurrencyAmount" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-6">
                    <label>Exchange Rate:</label>
                    <asp:TextBox ID="txtCurrencyRate" runat="server" CssClass="form-control" />
                </div>
            </div>

            <!-- Row 2: Optional Fee / Markup -->
            <div class="row mb-3">
                <div class="col-md-12">
                    <label>Fee / Markup (%):</label>
                    <asp:TextBox ID="txtCurrencyFee" runat="server" CssClass="form-control" Text="0" />
                </div>
            </div>

            <!-- Row 3: Optional Extra Target Currencies -->
            <div class="row mb-3">
                <div class="col-md-12">
                    <label>Additional Target Rates (comma separated, optional):</label>
                    <asp:TextBox ID="txtCurrencyExtraRates" runat="server" CssClass="form-control" Placeholder="e.g., 1.1,0.9,0.75" />
                </div>
            </div>

            <!-- Button -->
            <div class="mb-3">
                <asp:Button ID="btnCurrencyCalc" runat="server" Text="Convert" CssClass="btn btn-primary" OnClick="btnCurrencyCalc_Click" />
            </div>

            <!-- Result -->
            <div class="mb-3 mt-2">
                <asp:Label ID="lblCurrencyResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>

            <!-- History -->
            <div class="mb-3">
                <label>Conversion History:</label>
                <div id="divCurrencyHistory" runat="server" class="history-box" style="height:auto; min-height:100px; overflow:auto; white-space:pre-wrap;"></div>
            </div>
        </div>
    </asp:Panel>
</asp:View>


    <!-- 11. Goal Achievement Planner -->
    <asp:View ID="viewGoalPlanner" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Goal Achievement Planner</h4>
            <div class="mb-3">
                <label>Goal Description:</label>
                <asp:TextBox ID="txtGoalDesc" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Target Date (days from now):</label>
                <asp:TextBox ID="txtGoalDays" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnGoalCalc" runat="server" Text="Calculate Plan" CssClass="btn btn-primary" OnClick="btnGoalCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblGoalResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 12. Heart Rate / Target Zone Calculator -->
    <asp:View ID="viewHeartRate" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Heart Rate / Target Zone Calculator</h4>
            <div class="mb-3">
                <label>Age:</label>
                <asp:TextBox ID="txtHRAge" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnHRCalc" runat="server" Text="Calculate" CssClass="btn btn-primary" OnClick="btnHRCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblHRResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 13. Inventory Turnover Calculator -->
    <asp:View ID="viewInventoryTurnover" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Inventory Turnover Calculator</h4>
            <div class="mb-3">
                <label>Cost of Goods Sold:</label>
                <asp:TextBox ID="txtCOGS" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Average Inventory:</label>
                <asp:TextBox ID="txtAvgInventory" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnInventoryCalc" runat="server" Text="Calculate" CssClass="btn btn-primary" OnClick="btnInventoryCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblInventoryResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 14. Internal Rate of Return (IRR) Calculator (basic) -->
    <asp:View ID="viewIRR" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>IRR Calculator</h4>
            <div class="mb-3">
                <label>Initial Investment:</label>
                <asp:TextBox ID="txtIRRInvestment" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Final Value:</label>
                <asp:TextBox ID="txtIRRFinal" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnIRRCalc" runat="server" Text="Calculate" CssClass="btn btn-primary" OnClick="btnIRRCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblIRRResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 15. Loan Amortization Calculator -->
    <asp:View ID="viewLoanAmort" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Loan Amortization Calculator</h4>
            <div class="mb-3">
                <label>Loan Amount:</label>
                <asp:TextBox ID="txtLoanAmt" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Interest Rate (%):</label>
                <asp:TextBox ID="txtLoanInterest" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Term (Years):</label>
                <asp:TextBox ID="txtLoanTerm" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnLoanAmortCalc" runat="server" Text="Calculate" CssClass="btn btn-primary" OnClick="btnLoanAmortCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblLoanAmortResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 16. Macro Nutrient Calculator -->
    <asp:View ID="viewMacro" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Macro Nutrient Calculator</h4>
            <div class="mb-3">
                <label>Calories:</label>
                <asp:TextBox ID="txtMacroCalories" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Protein %:</label>
                <asp:TextBox ID="txtMacroProtein" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Carbs %:</label>
                <asp:TextBox ID="txtMacroCarbs" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Fat %:</label>
                <asp:TextBox ID="txtMacroFat" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnMacroCalc" runat="server" Text="Calculate" CssClass="btn btn-primary" OnClick="btnMacroCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblMacroResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 17. Markup / Margin Calculator -->
    <asp:View ID="viewMarkupMargin" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Markup / Margin Calculator</h4>
            <div class="mb-3">
                <label>Cost:</label>
                <asp:TextBox ID="txtCost" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Price:</label>
                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnMarkupCalc" runat="server" Text="Calculate" CssClass="btn btn-primary" OnClick="btnMarkupCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblMarkupResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 18. Mortgage Calculator -->
    <asp:View ID="viewMortgageCalc" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Mortgage Calculator</h4>
            <div class="mb-3">
                <label>Loan Amount:</label>
                <asp:TextBox ID="txtMortgageAmt" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Interest Rate (%):</label>
                <asp:TextBox ID="txtMortgageInterest" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Term (Years):</label>
                <asp:TextBox ID="txtMortgageTerm" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnMortgageCalc" runat="server" Text="Calculate" CssClass="btn btn-primary" OnClick="btnMortgageCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblMortgageResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 19. Net Present Value (NPV) Calculator -->
    <asp:View ID="viewNPV" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Net Present Value (NPV) Calculator</h4>
            <div class="mb-3">
                <label>Initial Investment:</label>
                <asp:TextBox ID="txtNPVInvestment" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Future Value:</label>
                <asp:TextBox ID="txtNPVFuture" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Discount Rate (%):</label>
                <asp:TextBox ID="txtNPVRate" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnNPVCalc" runat="server" Text="Calculate" CssClass="btn btn-primary" OnClick="btnNPVCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblNPVResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 20. Pet Weight / Dosage Calculator -->
    <asp:View ID="viewPetDosage" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Pet Weight / Dosage Calculator</h4>
            <div class="mb-3">
                <label>Pet Weight (kg):</label>
                <asp:TextBox ID="txtPetWeight" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Medication Dose (mg/kg):</label>
                <asp:TextBox ID="txtPetDose" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnPetCalc" runat="server" Text="Calculate" CssClass="btn btn-primary" OnClick="btnPetCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblPetResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 21. Physics Calculator (basic formula: F = m * a) -->
    <asp:View ID="viewPhysics" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Physics Calculator</h4>
            <div class="mb-3">
                <label>Mass (kg):</label>
                <asp:TextBox ID="txtMass" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Acceleration (m/s²):</label>
                <asp:TextBox ID="txtAcceleration" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnPhysicsCalc" runat="server" Text="Calculate Force" CssClass="btn btn-primary" OnClick="btnPhysicsCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblPhysicsResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 22. Price / Profit Calculator -->
    <asp:View ID="viewPriceProfit" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Price / Profit Calculator</h4>
            <div class="mb-3">
                <label>Cost:</label>
                <asp:TextBox ID="txtPriceCost" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Sale Price:</label>
                <asp:TextBox ID="txtPriceSale" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnPriceProfitCalc" runat="server" Text="Calculate" CssClass="btn btn-primary" OnClick="btnPriceProfitCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblPriceProfitResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 23. Pregnancy Calorie Calculator -->
    <asp:View ID="viewPregnancyCalorie" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Pregnancy Calorie Calculator</h4>
            <div class="mb-3">
                <label>Pre-pregnancy Weight (kg):</label>
                <asp:TextBox ID="txtPregWeight" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Height (cm):</label>
                <asp:TextBox ID="txtPregHeight" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Trimester (1/2/3):</label>
                <asp:TextBox ID="txtPregTrimester" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnPregCalc" runat="server" Text="Calculate" CssClass="btn btn-primary" OnClick="btnPregCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblPregResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 24. Productivity Calculator -->
    <asp:View ID="viewProductivity" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Productivity Calculator</h4>
            <div class="mb-3">
                <label>Total Tasks:</label>
                <asp:TextBox ID="txtProdTasks" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Completed Tasks:</label>
                <asp:TextBox ID="txtProdCompleted" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnProdCalc" runat="server" Text="Calculate Productivity (%)" CssClass="btn btn-primary" OnClick="btnProdCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblProdResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 25. Quadratic Equation Solver -->
    <asp:View ID="viewQuadratic" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Quadratic Equation Solver</h4>
            <p>Solves ax² + bx + c = 0</p>
            <div class="mb-3">
                <label>a:</label>
                <asp:TextBox ID="txtQuadA" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>b:</label>
                <asp:TextBox ID="txtQuadB" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>c:</label>
                <asp:TextBox ID="txtQuadC" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnQuadCalc" runat="server" Text="Solve" CssClass="btn btn-primary" OnClick="btnQuadCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblQuadResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 26. Retirement Planner -->
    <asp:View ID="viewRetirement" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Retirement Planner</h4>
            <div class="mb-3">
                <label>Current Savings:</label>
                <asp:TextBox ID="txtRetSavings" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Monthly Contribution:</label>
                <asp:TextBox ID="txtRetContribution" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Years to Retirement:</label>
                <asp:TextBox ID="txtRetYears" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnRetCalc" runat="server" Text="Calculate" CssClass="btn btn-primary" OnClick="btnRetCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblRetResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 27. ROI Calculator -->
    <asp:View ID="viewROI" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>ROI Calculator</h4>
            <div class="mb-3">
                <label>Initial Investment:</label>
                <asp:TextBox ID="txtROIInit" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Final Value:</label>
                <asp:TextBox ID="txtROIFinalVal" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnROICalc" runat="server" Text="Calculate" CssClass="btn btn-primary" OnClick="btnROICalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblROIResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 28. Savings Goal Calculator -->
    <asp:View ID="viewSavingsGoal" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Savings Goal Calculator</h4>
            <div class="mb-3">
                <label>Goal Amount:</label>
                <asp:TextBox ID="txtGoalAmount" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Monthly Savings:</label>
                <asp:TextBox ID="txtGoalMonthly" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnGoalAmountCalc" runat="server" Text="Calculate Months Needed" CssClass="btn btn-primary" OnClick="btnGoalAmountCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblGoalAmountResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 29. Sleep Needs Calculator -->
    <asp:View ID="viewSleepNeeds" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Sleep Needs Calculator</h4>
            <div class="mb-3">
                <label>Age:</label>
                <asp:TextBox ID="txtSleepAge" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnSleepCalc" runat="server" Text="Calculate Hours Needed" CssClass="btn btn-primary" OnClick="btnSleepCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblSleepResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 30. Stock Investment Calculator -->
    <asp:View ID="viewStockInvestment" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Stock Investment Calculator</h4>
            <div class="mb-3">
                <label>Initial Investment:</label>
                <asp:TextBox ID="txtStockInit" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Final Value:</label>
                <asp:TextBox ID="txtStockFinal" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnStockCalc" runat="server" Text="Calculate ROI" CssClass="btn btn-primary" OnClick="btnStockCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblStockResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 31. Study / Learning Time Planner -->
    <asp:View ID="viewStudyPlanner" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Study / Learning Time Planner</h4>
            <div class="mb-3">
                <label>Total Hours Available:</label>
                <asp:TextBox ID="txtStudyTotalHours" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Subjects to Study:</label>
                <asp:TextBox ID="txtStudySubjects" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnStudyCalc" runat="server" Text="Calculate Time per Subject" CssClass="btn btn-primary" OnClick="btnStudyCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblStudyResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 32. TDEE Calculator -->
    <asp:View ID="viewTDEE" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>TDEE Calculator</h4>
            <div class="mb-3">
                <label>Weight (kg):</label>
                <asp:TextBox ID="txtTDEEWeight" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Height (cm):</label>
                <asp:TextBox ID="txtTDEEHeight" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Age:</label>
                <asp:TextBox ID="txtTDEEAge" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Gender (M/F):</label>
                <asp:TextBox ID="txtTDEEGender" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Activity Level (1-5):</label>
                <asp:TextBox ID="txtTDEEActivity" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnTDEECalc" runat="server" Text="Calculate TDEE" CssClass="btn btn-primary" OnClick="btnTDEECalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblTDEResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 33. Travel / Fuel Cost Calculator -->
    <asp:View ID="viewTravelFuel" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Travel / Fuel Cost Calculator</h4>
            <div class="mb-3">
                <label>Distance (km):</label>
                <asp:TextBox ID="txtTravelDistance" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Fuel Efficiency (km/l):</label>
                <asp:TextBox ID="txtTravelEfficiency" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Fuel Price per Liter:</label>
                <asp:TextBox ID="txtTravelFuelPrice" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnTravelCalc" runat="server" Text="Calculate Cost" CssClass="btn btn-primary" OnClick="btnTravelCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblTravelResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 34. Unit Conversion Calculator -->
    <asp:View ID="viewUnitConversion" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Unit Conversion Calculator</h4>
            <div class="mb-3">
                <label>Value:</label>
                <asp:TextBox ID="txtUnitValue" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>From Unit:</label>
                <asp:TextBox ID="txtUnitFrom" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>To Unit:</label>
                <asp:TextBox ID="txtUnitTo" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnUnitConvert" runat="server" Text="Convert" CssClass="btn btn-primary" OnClick="btnUnitConvert_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblUnitResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 35. VAT / Tax Calculator -->
    <asp:View ID="viewVAT" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>VAT / Tax Calculator</h4>
            <div class="mb-3">
                <label>Price:</label>
                <asp:TextBox ID="txtVATPrice" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Tax Rate (%):</label>
                <asp:TextBox ID="txtVATRate" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnVATCalc" runat="server" Text="Calculate" CssClass="btn btn-primary" OnClick="btnVATCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblVATResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 37. Pomodoro / Focus Timer -->
    <asp:View ID="viewPomodoro" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Pomodoro / Focus Timer</h4>
            <div class="mb-3">
                <label>Work Minutes:</label>
                <asp:TextBox ID="txtPomWork" runat="server" CssClass="form-control" Text="25" />
            </div>
            <div class="mb-3">
                <label>Break Minutes:</label>
                <asp:TextBox ID="txtPomBreak" runat="server" CssClass="form-control" Text="5" />
            </div>
            <asp:Button ID="btnPomodoroStart" runat="server" Text="Start Timer" CssClass="btn btn-primary" OnClick="btnPomodoroStart_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblPomResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 37. Water Intake Calculator -->
    <asp:View ID="viewWaterIntake" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Water Intake Calculator</h4>
            <div class="mb-3">
                <label>Weight (kg):</label>
                <asp:TextBox ID="txtWaterWeight" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnWaterCalc" runat="server" Text="Calculate Liters Needed" CssClass="btn btn-primary" OnClick="btnWaterCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblWaterResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 38. Chemistry Molarity Calculator -->
    <asp:View ID="viewChemMolarity" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Chemistry Molarity Calculator</h4>
            <div class="mb-3">
                <label>Moles:</label>
                <asp:TextBox ID="txtChemMoles" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Volume (Liters):</label>
                <asp:TextBox ID="txtChemVolume" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnChemCalc" runat="server" Text="Calculate Molarity" CssClass="btn btn-primary" OnClick="btnChemCalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblChemResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>

    <!-- 39. Body Surface Area Calculator -->
    <asp:View ID="viewBSA" runat="server">
        <div class="card shadow-sm mb-4 p-4">
            <h4>Body Surface Area Calculator</h4>
            <div class="mb-3">
                <label>Weight (kg):</label>
                <asp:TextBox ID="txtBSAWeight" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Height (cm):</label>
                <asp:TextBox ID="txtBSAHeight" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnBSACalc" runat="server" Text="Calculate BSA" CssClass="btn btn-primary" OnClick="btnBSACalc_Click" />
            <div class="mb-3 mt-2">
                <asp:Label ID="lblBSAResult" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>
    </asp:View>


</asp:MultiView>


    </div>
  
     <!-- Scripts for Select2 (searchable dropdown) and print -->
    <link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.min.js"></script>

    <script>
        $(document).ready(function () {
            $('#<%= ddlCalculators.ClientID %>').select2({
                placeholder: "Select a calculator...",
                allowClear: true,
                width: '100%'
            });
        });

        function printCalculator() {
            const title = document.getElementById('<%= txtCalcTitle.ClientID %>').value;
            const desc = document.getElementById('<%= txtCalcDesc.ClientID %>').value;

            // Grab the card content (active view)
            let content = document.querySelector('.card').outerHTML;

            // Open a new window
            let printWindow = window.open('', '_blank', 'height=700,width=900');

            // Write the full HTML
            printWindow.document.open();
            printWindow.document.write(`
                <!DOCTYPE html>
                <html>
                <head>
                    <title>${title || 'Calculator Printout'}</title>
                    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
                    <style>
                        body { font-family: Arial, sans-serif; margin: 20px; }
                        h2 { margin-bottom: 10px; }
                        p { margin-bottom: 20px; }
                    </style>
                </head>
                <body>
                    ${title ? `<h2>${title}</h2>` : ''}
                    ${desc ? `<p>${desc}</p>` : ''}
                    ${content}
                </body>
                </html>
            `);
            printWindow.document.close(); // Ensure DOM is ready
            printWindow.focus();          // Focus for printing
            setTimeout(() => {
                printWindow.print();
                printWindow.close();
            }, 200); // Small delay to ensure rendering
            return false;
        }

    </script>
    <style>
        .history-box {
          white-space: pre-wrap;        /* preserve line breaks */
          overflow: visible;           /* no scrollbars */
          min-height: 6em;             /* starting height */
          padding: .5rem;
          border: 1px solid #ced4da;
          border-radius: .25rem;
          background: #f8f9fa;
          font-family: "Courier New", monospace; /* monospaced makes history easy to read */
          font-size: 0.9rem;
        }

    </style>
</asp:Content>

