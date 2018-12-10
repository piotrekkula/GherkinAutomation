Feature: Once used but not anymore 
	Set of scenarios that were used once but not anymore.

@continue_filling_sHCP_Form
Scenario Outline: Continue filling sHCP Form
	When User searches for existing form and opens it
	Then Form is in view mode
	When I click Edit
	And I fill in Meal Description with following data:
		| <nomeal>	| <mealtype> | <mealestcosts> | <numberofmeals> | <mealcurrency> | <mealrestaurantname> | <mealcomments> | <breakfastin> |
	Then Meal Description is filled correctly
		| <nomeal>	| <mealtype> | <mealestcosts> | <numberofmeals> | <mealcurrency> | <mealrestaurantname> | <mealcomments> | <breakfastin> |

Examples:
| engownername | globalfunction | jobtitle | engagementpaidby | function | hcpcoord | linemanager | hcpcountry | hcpfirstname | hcplastname | therapeuticarea  | productbrandmolecule | indication | protocolnumber | engagementtitle | congress | engagementtype | alldayengagement | engagementvenue | engagementcity | engagementcountry | engagementstateprovince | scimedbusneeds | engagementobjective | contractedservice | description | affcontact           | hcproleselect | rationalforhcp       | areaofexpertise | nofee | totalactivitytime | preptime | hourlyrate | flatrate | totaldisturbancefee | currency | noaccomodation | accnametolookup | acccostspernight | accnrofnights | acccurrency | accdescription     | nomeal | mealtype | mealestcosts | numberofmeals | mealcurrency | mealrestaurantname     | mealcomments        | breakfastin | notravel | traveltype | travelcategory | travelestcosts | travelcurrency | traveldescription         | noothercosts | othcoststype | othcostsamount | othcostscurrency | othcostscomment | localreqfull | locreqsubmit   | locreqspecify | scenarioID |
| iHCP_01      | Yes            | JobTitle | GPS              | GPS      | iHCP_02  | iHCP_03     | US         | john         | kennedy     | CardioMetabolism | Actemra              | Anemia     | 1234567        | someTitle       | AAN      | Consulting     | No               | optional        | Poznan         | US                | Georgia                 | optional       | optional            | No                | optional    | iHCP 04 Test User 04 | Consultant    | Guidelines Expertise | optional        | Yes   | 10.05             | 10.00    | 10.00      | 0.00     | 10.00               | ALL(Lek) | Yes            | sdf             | 5.55             | 7             | ALL(Lek)    | sample description | No     | Dinner   | 5.23         | 7             | ALL(Lek)     | sample restaurant name | sample meal comment | No          | No       | Flight     | Business       | 555.23         | ALL(Lek)       | sample travel description | No           | 123          | 555.05         | ALL(Lek)         | sample comment  | Yes          | yes            | Description   | ^ID50      |