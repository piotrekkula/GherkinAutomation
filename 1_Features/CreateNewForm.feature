Feature: Creating New Form.
		In order to keep track of information regarding enegagements,
		as an engagement owner,
		I want to be able to create new engagement form.

Background:
Given I am logged in as engagementOwner
#######################################

@Generate_New_Form
Scenario Outline: Creating New sHCP Form
	When I clicked New Form button
	Then sHCP Form option is visible
	When I select sHCP option
	And I click Next button
	Then New sHCP Form opens
	When I fill in Engagement Owner Details with following data:
		| <engownername>	| <globalfunction>	| <jobtitle> | <engagementpaidby>	| <function> |
	Then Engagement Owner Details is filled correctly
		| <engownername>	| <globalfunction>	| <jobtitle> | <engagementpaidby>	| <function> |
	When I fill in HCP Coordinator Section as <hcpcoord>
	Then HCP Coordinator Section is filled with <hcpcoord> 
	When I fill in Line Manager as <linemanager>
	Then Line Manager section is filled as <linemanager>
	When I fill in Healthcare Professional Details
		| <hcpcountry> | <hcpfirstname> | <hcplastname> |
	Then Healthcare Professional Details is filled
		| <hcpcountry> | <hcpfirstname> | <hcplastname> |
	When I fill in Product Information with following data:
		| <therapeuticarea>	| <productbrandmolecule> | <indication>	| <protocolnumber>	|
	Then Product Information is filled correctly
		| <therapeuticarea>	| <productbrandmolecule> | <indication>	| <protocolnumber>	|
	When I fill in Engagement Description with following data:
		| <engagementtitle>	| <congress>	| <engagementtype> | <alldayengagement> | <engagementvenue> | <engagementcity>	| <engagementcountry>	| <engagementstateprovince> | <scimedbusneeds>	| <engagementobjective>	| <contractedservice>	| <description>	|
	Then Engagement Description is filled correctly
		| <engagementtitle>	| <congress>	| <engagementtype> | <alldayengagement> | <engagementvenue> | <engagementcity>	| <engagementcountry>	| <engagementstateprovince> | <scimedbusneeds>	| <engagementobjective>	| <contractedservice>	| <description>	|
	When I fill in Affiliate Contact as <affcontact>
	Then Affiliate Contact is filled as <affcontact>
	When I fill in HCP Role with following data:
		| <hcproleselect>	| <rationalforhcp>	|  <areaofexpertise> |
	Then HCP Role is filled correctly
		| <hcproleselect>	| <rationalforhcp>	|  <areaofexpertise> |
	When I fill in Fee for Service with following data:
		| <nofee>	| <totalactivitytime> | <preptime> | <hourlyrate> | <flatrate> | <totaldisturbancefee> | <currency> |
	Then Fee for Service is filled correctly
		| <nofee>	| <totalactivitytime> | <preptime> | <hourlyrate> | <flatrate> | <totaldisturbancefee> | <currency> |
	When I fill in Accomodation Description with following data:
		| <noaccomodation>	| <accnametolookup> | <acccostspernight> | <accnrofnights> | <acccurrency> | <accdescription> |
	Then Accomodation Description is filled correctly
		| <noaccomodation>	| <accnametolookup> | <acccostspernight> | <accnrofnights> | <acccurrency> | <accdescription> |
	When I fill in Meal Description with following data:
		| <nomeal>	| <mealtype> | <mealestcosts> | <numberofmeals> | <mealcurrency> | <mealrestaurantname> | <mealcomments> | <breakfastin> |
	Then Meal Description is filled correctly
		| <nomeal>	| <mealtype> | <mealestcosts> | <numberofmeals> | <mealcurrency> | <mealrestaurantname> | <mealcomments> | <breakfastin> |
	When I fill in Travel Details with following data:
		| <notravel> | <traveltype> | <travelcategory> | <travelestcosts> | <travelcurrency> | <traveldescription> |
	Then Travel Details is filled correctly
		| <notravel> | <traveltype> | <travelcategory> | <travelestcosts> | <travelcurrency> | <traveldescription> |
	When I fill in Other Costs with following data:
		| <noothercosts> | <othcoststype> | <othcostsamount> | <othcostscurrency> | <othcostscomment> |
	Then Other Costs is filled correctly
		| <noothercosts> | <othcoststype> | <othcostsamount> | <othcostscurrency> | <othcostscomment> |
	When I fill in Local Requirements with following data:
		| <localreqfull> | <locreqsubmit> | <locreqspecify> | 
	Then Local Requirements is filled correctly
		| <localreqfull> | <locreqsubmit> | <locreqspecify> |
	When I fill in Information section
	Then Information Section is filled correctly 
	When I click Save Form Button
	Then sHCP Form is in view mode
	And New sHCP form is verified
		| <engownername> | <globalfunction>	| <jobtitle> | <engagementpaidby> | <function> | <hcpcoord> | <linemanager> | <hcpcountry> | <hcpfirstname> | <hcplastname> | <therapeuticarea>	| <productbrandmolecule> | <indication>	| <protocolnumber> | <engagementtitle>	| <congress>	| <engagementtype> | <alldayengagement> | <engagementvenue> | <engagementcity>	| <engagementcountry>	| <engagementstateprovince> | <scimedbusneeds>	| <engagementobjective>	| <contractedservice>	| <description>	| <affcontact> | <hcproleselect> | <rationalforhcp>	|  <areaofexpertise> | <nofee>	| <totalactivitytime> | <preptime> | <hourlyrate> | <flatrate> | <totaldisturbancefee> | <currency> | <noaccomodation>	| <accnametolookup> | <acccostspernight> | <accnrofnights> | <acccurrency> | <accdescription> | <nomeal> | <mealtype> | <mealestcosts> | <numberofmeals> | <mealcurrency> | <mealrestaurantname> | <mealcomments> | <breakfastin> | <notravel> | <traveltype> | <travelcategory> | <travelestcosts> | <travelcurrency> | <traveldescription> | <noothercosts> | <othcoststype> | <othcostsamount> | <othcostscurrency> | <othcostscomment> | <localreqfull> | <locreqsubmit> | <locreqspecify> |
	When I click Logout Link
	Then I am logged out

Examples:
| engownername | globalfunction | jobtitle | engagementpaidby | function | hcpcoord | linemanager | hcpcountry | hcpfirstname | hcplastname | therapeuticarea  | productbrandmolecule | indication | protocolnumber | engagementtitle | congress | engagementtype | alldayengagement | engagementvenue | engagementcity | engagementcountry | engagementstateprovince | scimedbusneeds | engagementobjective | contractedservice | description | affcontact           | hcproleselect | rationalforhcp       | areaofexpertise | nofee | totalactivitytime | preptime | hourlyrate | flatrate | totaldisturbancefee | currency | noaccomodation | accnametolookup | acccostspernight | accnrofnights | acccurrency | accdescription     | nomeal | mealtype | mealestcosts | numberofmeals | mealcurrency | mealrestaurantname     | mealcomments        | breakfastin | notravel | traveltype | travelcategory | travelestcosts | travelcurrency | traveldescription         | noothercosts | othcoststype | othcostsamount | othcostscurrency | othcostscomment | localreqfull | locreqsubmit   | locreqspecify | scenarioID |
| iHCP_01      | Yes            | JobTitle | GPS              | GPS      | iHCP_02  | iHCP_03     | US         | john         | kennedy     | CardioMetabolism | Actemra              | Anemia     | 1234567        | someTitle       | AAN      | Consulting     | No               | optional        | Poznan         | US                | Georgia                 | optional       | optional            | No                | optional    | iHCP 04 Test User 04 | Consultant    | Guidelines Expertise | optional        | No    | 10.05             | 10.00    | 10.00      | 0.00     | 10.00               | ALL(Lek) | No             | sdf             | 5.55             | 7             | ALL(Lek)    | sample description | No     | Dinner   | 5.23         | 7             | ALL(Lek)     | sample restaurant name | sample meal comment | No          | No       | Flight     | Business       | 555.23         | ALL(Lek)       | sample travel description | No           | 123          | 555.05         | ALL(Lek)         | sample comment  | Yes          | yes            | Description   | ^ID00      |
| iHCP_01      | Yes            | JobTitle | GPS              | GPS      | iHCP_02  | iHCP_03     | US         | john         | kennedy     | CardioMetabolism | Actemra              | Anemia     | 1234567        | someTitle       | AAN      | Consulting     | No               | optional        | Poznan         | Poland            | Slovakia                | optional       | optional            | No                | optional    | iHCP 04 Test User 04 | Consultant    | Guidelines Expertise | optional        | No    | 10.05             | 10.00    | 10.00      | 0.00     | 10.00               | ALL(Lek) | No             | sdf             | 5.55             | 7             | ALL(Lek)    | sample description | No     | Dinner   | 5.23         | 7             | ALL(Lek)     | sample restaurant name | sample meal comment | Yes         | No       | Flight     | Business       | 555.23         | ALL(Lek)       | sample travel description | No           | 123          | 555.05         | ALL(Lek)         | sample comment  | Yes          | not applicable | Description   | ^ID01      |
| iHCP_01      | Yes            | JobTitle | GPS              | GPS      | iHCP_02  | iHCP_03     | US         | john         | kennedy     | CardioMetabolism | Actemra              | Anemia     | 1234567        | someTitle       | AAN      | Consulting     | No               | optional        | Poznan         | US                | Georgia                 | optional       | optional            | No                | optional    | iHCP 04 Test User 04 | Consultant    | Guidelines Expertise | optional        | No    | 10.05             | 10.00    | 10.00      | 0.00     | 10.00               | ALL(Lek) | No             | sdf             | 5.55             | 7             | ALL(Lek)    | sample description | No     | Dinner   | 5.23         | 7             | ALL(Lek)     | sample restaurant name | sample meal comment | No          | No       | Flight     | Business       | 555.23         | ALL(Lek)       | sample travel description | No           | 123          | 555.05         | ALL(Lek)         | sample comment  | Yes          | yes            | Description   | ^ID02      |

##########################################################################################

@Generate_New_Form
Scenario Outline: Creating New mHCP Form
	When I clicked New Form button
	Then mHCP Form option is visible
	When I select mHCP option
	And I click Next button
	Then New mHCP Form opens
	When I fill in Engagement Owner Details with following data:
		| <engownername>	| <globalfunction>	| <jobtitle> | <engagementpaidby>	| <function> |
	Then Engagement Owner Details is filled correctly
		| <engownername>	| <globalfunction>	| <jobtitle> | <engagementpaidby>	| <function> |
	When I fill in HCP Coordinator Section as <hcpcoord>
	Then HCP Coordinator Section is filled with <hcpcoord> 
	When I fill in Line Manager as <linemanager>
	Then Line Manager section is filled as <linemanager>
	When I fill in multiple Healthcare Professional Details
		| <hcpcountry> | <hcpfirstname> | <hcplastname> | <hcpfirstname2> | <hcplastname2> | 
	Then Healthcare Professional Details is filled
		| <hcpcountry> | <hcpfirstname> | <hcplastname> |
	When I fill in Product Information with following data:
		| <therapeuticarea>	| <productbrandmolecule> | <indication>	| <protocolnumber>	|
	Then Product Information is filled correctly
		| <therapeuticarea>	| <productbrandmolecule> | <indication>	| <protocolnumber>	|
	When I fill in Engagement Description with following data:
		| <engagementtitle>	| <congress>	| <engagementtype> | <alldayengagement> | <engagementvenue> | <engagementcity>	| <engagementcountry>	| <engagementstateprovince> | <scimedbusneeds>	| <engagementobjective>	| <contractedservice>	| <description>	|
	Then Engagement Description is filled correctly
		| <engagementtitle>	| <congress>	| <engagementtype> | <alldayengagement> | <engagementvenue> | <engagementcity>	| <engagementcountry>	| <engagementstateprovince> | <scimedbusneeds>	| <engagementobjective>	| <contractedservice>	| <description>	|
	When I fill in Affiliate Contact as <affcontact>
	Then Affiliate Contact is filled as <affcontact>
	When I fill in HCP Role with following data:
		| <hcproleselect>	| <rationalforhcp>	|  <areaofexpertise> |
	Then HCP Role is filled correctly
		| <hcproleselect>	| <rationalforhcp>	|  <areaofexpertise> |
	When I fill in Fee for Service with following data:
		| <nofee>	| <totalactivitytime> | <preptime> | <hourlyrate> | <flatrate> | <totaldisturbancefee> | <currency> |
	Then Fee for Service is filled correctly
		| <nofee>	| <totalactivitytime> | <preptime> | <hourlyrate> | <flatrate> | <totaldisturbancefee> | <currency> |
	When I fill in Accomodation Description with following data:
		| <noaccomodation>	| <accnametolookup> | <acccostspernight> | <accnrofnights> | <acccurrency> | <accdescription> |
	Then Accomodation Description is filled correctly
		| <noaccomodation>	| <accnametolookup> | <acccostspernight> | <accnrofnights> | <acccurrency> | <accdescription> |
	When I fill in Meal Description with following data:
		| <nomeal>	| <mealtype> | <mealestcosts> | <numberofmeals> | <mealcurrency> | <mealrestaurantname> | <mealcomments> | <breakfastin> |
	Then Meal Description is filled correctly
		| <nomeal>	| <mealtype> | <mealestcosts> | <numberofmeals> | <mealcurrency> | <mealrestaurantname> | <mealcomments> | <breakfastin> |
	When I fill in Travel Details with following data:
		| <notravel> | <traveltype> | <travelcategory> | <travelestcosts> | <travelcurrency> | <traveldescription> |
	Then Travel Details is filled correctly
		| <notravel> | <traveltype> | <travelcategory> | <travelestcosts> | <travelcurrency> | <traveldescription> |
	When I fill in Other Costs with following data:
		| <noothercosts> | <othcoststype> | <othcostsamount> | <othcostscurrency> | <othcostscomment> |
	Then Other Costs is filled correctly
		| <noothercosts> | <othcoststype> | <othcostsamount> | <othcostscurrency> | <othcostscomment> |
	When I fill in Local Requirements with following data:
		| <localreqfull> | <locreqsubmit> | <locreqspecify> |
	Then Local Requirements is filled correctly
		| <localreqfull> | <locreqsubmit> | <locreqspecify> |
	When I fill in Information section
	Then Information Section is filled correctly 
	When I click Save Form Button
	Then mHCP Form is in view mode
	And New mHCP form is verified
		| <engownername> | <globalfunction>	| <jobtitle> | <engagementpaidby> | <function> | <hcpcoord> | <linemanager> | <hcpcountry> | <hcpfirstname> | <hcplastname> | <hcpfirstname2> | <hcplastname2> | <therapeuticarea>	| <productbrandmolecule> | <indication>	| <protocolnumber> | <engagementtitle>	| <congress>	| <engagementtype> | <alldayengagement> | <engagementvenue> | <engagementcity>	| <engagementcountry>	| <engagementstateprovince> | <scimedbusneeds>	| <engagementobjective>	| <contractedservice>	| <description>	| <affcontact> | <hcproleselect> | <rationalforhcp>	|  <areaofexpertise> | <nofee>	| <totalactivitytime> | <preptime> | <hourlyrate> | <flatrate> | <totaldisturbancefee> | <currency> | <noaccomodation>	| <accnametolookup> | <acccostspernight> | <accnrofnights> | <acccurrency> | <accdescription> | <nomeal> | <mealtype> | <mealestcosts> | <numberofmeals> | <mealcurrency> | <mealrestaurantname> | <mealcomments> | <breakfastin> | <notravel> | <traveltype> | <travelcategory> | <travelestcosts> | <travelcurrency> | <traveldescription> | <noothercosts> | <othcoststype> | <othcostsamount> | <othcostscurrency> | <othcostscomment> | <localreqfull> | <locreqsubmit> | <locreqspecify> |
	When I click Logout Link
	Then I am logged out

Examples:
| engownername | globalfunction | jobtitle | engagementpaidby | function | hcpcoord | linemanager | hcpcountry | hcpfirstname | hcplastname | hcpfirstname2 | hcplastname2 | therapeuticarea  | productbrandmolecule | indication | protocolnumber | engagementtitle | congress | engagementtype | alldayengagement | engagementvenue | engagementcity | engagementcountry | engagementstateprovince | scimedbusneeds | engagementobjective | contractedservice | description | affcontact           | hcproleselect | rationalforhcp       | areaofexpertise | nofee | totalactivitytime | preptime | hourlyrate | flatrate | totaldisturbancefee | currency | noaccomodation | accnametolookup | acccostspernight | accnrofnights | acccurrency | accdescription     | nomeal | mealtype | mealestcosts | numberofmeals | mealcurrency | mealrestaurantname     | mealcomments        | breakfastin | notravel | traveltype | travelcategory | travelestcosts | travelcurrency | traveldescription         | noothercosts | othcoststype | othcostsamount | othcostscurrency | othcostscomment | localreqfull | locreqsubmit | locreqspecify | scenarioID |
| iHCP_01      | Yes            | JobTitle | GPS              | GPS      | iHCP_02  | iHCP_03     | US         | john         | kennedy     | Mark          | Johnson      | CardioMetabolism | Actemra              | Anemia     | 1234567        | someTitle       | AAN      | Consulting     | Yes              | optional        | Poznan         | US                | Georgia                 | optional       | optional            | No                | optional    | iHCP 04 Test User 04 | Consultant    | Guidelines Expertise | optional        | No    | 10.05             | 10.00    | 10.00      | 0.00     | 10.00               | ALL(Lek) | No             | sdf             | 5.55             | 7             | ALL(Lek)    | sample description | No     | Dinner   | 5.23         | 7             | ALL(Lek)     | sample restaurant name | sample meal comment | No          | No       | Flight     | Business       | 555.23         | ALL(Lek)       | sample travel description | No           | 123          | 555.05         | ALL(Lek)         | sample comment  | Yes          | yes          | Description   | ^ID10      |
| iHCP_01      | Yes            | JobTitle | GPS              | GPS      | iHCP_02  | iHCP_03     | US         | john         | kennedy     | Mark          | Johnson      | CardioMetabolism | Actemra              | Anemia     | 1234567        | someTitle       | AAN      | Consulting     | Yes              | optional        | Poznan         | US                | Georgia                 | optional       | optional            | No                | optional    | iHCP 04 Test User 04 | Consultant    | Guidelines Expertise | optional        | No    | 10.05             | 10.00    | 10.00      | 0.00     | 10.00               | ALL(Lek) | No             | sdf             | 5.55             | 7             | ALL(Lek)    | sample description | No     | Dinner   | 5.23         | 7             | ALL(Lek)     | sample restaurant name | sample meal comment | No          | No       | Flight     | Business       | 555.23         | ALL(Lek)       | sample travel description | No           | 123          | 555.05         | ALL(Lek)         | sample comment  | Yes          | yes          | Description   | ^ID11      |
| iHCP_01      | Yes            | JobTitle | GPS              | GPS      | iHCP_02  | iHCP_03     | US         | john         | kennedy     | Mark          | Johnson      | CardioMetabolism | Actemra              | Anemia     | 1234567        | someTitle       | AAN      | Consulting     | Yes              | optional        | Poznan         | US                | Georgia                 | optional       | optional            | No                | optional    | iHCP 04 Test User 04 | Consultant    | Guidelines Expertise | optional        | No    | 10.05             | 10.00    | 10.00      | 0.00     | 10.00               | ALL(Lek) | No             | sdf             | 5.55             | 7             | ALL(Lek)    | sample description | No     | Dinner   | 5.23         | 7             | ALL(Lek)     | sample restaurant name | sample meal comment | No          | No       | Flight     | Business       | 555.23         | ALL(Lek)       | sample travel description | No           | 123          | 555.05         | ALL(Lek)         | sample comment  | Yes          | yes          | Description   | ^ID12      |

##########################################################################################

@Generate_New_Form
Scenario Outline: Creating New uHCP Form
	When I clicked New Form button
	Then uHCP Form option is visible
	When I select uHCP option
	And I click Next button
	Then New uHCP Form opens
	When I fill in Engagement Owner Details with following data:
		| <engownername>	| <globalfunction>	| <jobtitle> | <engagementpaidby>	| <function> |
	Then Engagement Owner Details is filled correctly
		| <engownername>	| <globalfunction>	| <jobtitle> | <engagementpaidby>	| <function> |
	When I fill in HCP Coordinator Section as <hcpcoord>
	Then HCP Coordinator Section is filled with <hcpcoord> 
	When I fill in Line Manager as <linemanager>
	Then Line Manager section is filled as <linemanager>
	When I fill in multiple Healthcare Professional Details
		| <hcpcountry> | <hcpfirstname> | <hcplastname> | <hcpfirstname2> | <hcplastname2> | 
	Then Healthcare Professional Details is filled
		| <hcpcountry> | <hcpfirstname> | <hcplastname> |
	When I fill in Product Information with following data:
		| <therapeuticarea>	| <productbrandmolecule> | <indication>	| <protocolnumber>	|
	Then Product Information is filled correctly
		| <therapeuticarea>	| <productbrandmolecule> | <indication>	| <protocolnumber>	|
	When I fill in Engagement Description with following data:
		| <engagementtitle>	| <congress>	| <engagementtype> | <alldayengagement> | <engagementvenue> | <engagementcity>	| <engagementcountry>	| <engagementstateprovince> | <scimedbusneeds>	| <engagementobjective>	| <contractedservice>	| <description>	|
	Then Engagement Description is filled correctly
		| <engagementtitle>	| <congress>	| <engagementtype> | <alldayengagement> | <engagementvenue> | <engagementcity>	| <engagementcountry>	| <engagementstateprovince> | <scimedbusneeds>	| <engagementobjective>	| <contractedservice>	| <description>	|
	When I fill in Affiliate Contact as <affcontact>
	Then Affiliate Contact is filled as <affcontact>
	When I fill in Meal Description with following data:
		| <nomeal>	| <mealtype> | <mealestcosts> | <numberofmeals> | <mealcurrency> | <mealrestaurantname> | <mealcomments> | <breakfastin> |
	Then Meal Description is filled correctly
		| <nomeal>	| <mealtype> | <mealestcosts> | <numberofmeals> | <mealcurrency> | <mealrestaurantname> | <mealcomments> | <breakfastin> |
	When I fill in Other Costs with following data:
		| <noothercosts> | <othcoststype> | <othcostsamount> | <othcostscurrency> | <othcostscomment> |
	Then Other Costs is filled correctly
		| <noothercosts> | <othcoststype> | <othcostsamount> | <othcostscurrency> | <othcostscomment> |
	When I click Save Form Button
	Then uHCP Form is in view mode
	And New uHCP form is verified
		| <engownername> | <globalfunction>	| <jobtitle> | <engagementpaidby> | <function> | <hcpcoord> | <linemanager> | <hcpcountry> | <hcpfirstname> | <hcplastname> | <hcpfirstname2> | <hcplastname2> | <therapeuticarea>	| <productbrandmolecule> | <indication>	| <protocolnumber> | <engagementtitle>	| <congress>	| <engagementtype> | <alldayengagement> | <engagementvenue> | <engagementcity>	| <engagementcountry>	| <engagementstateprovince> | <scimedbusneeds>	| <engagementobjective>	| <contractedservice> | <description> | <affcontact> | <nomeal> | <mealtype> | <mealestcosts> | <numberofmeals> | <mealcurrency> | <mealrestaurantname> | <mealcomments> | <breakfastin> | <noothercosts> | <othcoststype> | <othcostsamount> | <othcostscurrency> | <othcostscomment> |
	When I click Logout Link
	Then I am logged out

Examples:
| engownername | globalfunction | jobtitle | engagementpaidby | function | hcpcoord | linemanager | hcpcountry | hcpfirstname | hcplastname | hcpfirstname2 | hcplastname2 | therapeuticarea  | productbrandmolecule | indication | protocolnumber | engagementtitle | congress | engagementtype | alldayengagement | engagementvenue | engagementcity | engagementcountry | engagementstateprovince | scimedbusneeds | engagementobjective | contractedservice | description | affcontact           | nomeal | mealtype | mealestcosts | numberofmeals | mealcurrency | mealrestaurantname     | mealcomments        | breakfastin | noothercosts | othcoststype | othcostsamount | othcostscurrency | othcostscomment | scenarioID |
| iHCP_01      | Yes            | JobTitle | GPS              | GPS      | iHCP_02  | iHCP_03     | US         | john         | kennedy     | Mark          | Johnson      | CardioMetabolism | Actemra              | Anemia     | 1234567        | someTitle       | AAN      | Consulting     | Yes              | optional        | Poznan         | US                | Georgia                 | optional       | optional            | No                | optional    | iHCP 04 Test User 04 | No     | Dinner   | 5.23         | 7             | ALL(Lek)     | sample restaurant name | sample meal comment | No          | No           | 123          | 555.05         | ALL(Lek)         | sample comment  | ^ID20      |
| iHCP_01      | Yes            | JobTitle | GPS              | GPS      | iHCP_02  | iHCP_03     | US         | john         | kennedy     | Mark          | Johnson      | CardioMetabolism | Actemra              | Anemia     | 1234567        | someTitle       | AAN      | Consulting     | Yes              | optional        | Poznan         | US                | Georgia                 | optional       | optional            | No                | optional    | iHCP 04 Test User 04 | No     | Dinner   | 5.23         | 7             | ALL(Lek)     | sample restaurant name | sample meal comment | No          | No           | 123          | 555.05         | ALL(Lek)         | sample comment  | ^ID21      |
| iHCP_01      | Yes            | JobTitle | GPS              | GPS      | iHCP_02  | iHCP_03     | US         | john         | kennedy     | Mark          | Johnson      | CardioMetabolism | Actemra              | Anemia     | 1234567        | someTitle       | AAN      | Consulting     | Yes              | optional        | Poznan         | US                | Georgia                 | optional       | optional            | No                | optional    | iHCP 04 Test User 04 | No     | Dinner   | 5.23         | 7             | ALL(Lek)     | sample restaurant name | sample meal comment | No          | No           | 123          | 555.05         | ALL(Lek)         | sample comment  | ^ID22      |

##########################################################################################


@US_sHCP
Scenario Outline: 01.sHCP_creation_US
	When I clicked New Form button
	Then sHCP Form option is visible
	When I select sHCP option
	And I click Next button
	Then New sHCP Form opens
	When I fill in Engagement Owner Details with following data:
		| <engownername>	| <globalfunction>	| <jobtitle> | <engagementpaidby>	| <function> |
	Then Engagement Owner Details is filled correctly
		| <engownername>	| <globalfunction>	| <jobtitle> | <engagementpaidby>	| <function> |
	When User clicks Save button
	Then sHCP Form is in view mode
	When User adds Note to Form
	Then Note is added to form
	When User adds Attachment to Form
	Then Attachment is added to form
	When User clicks Edit button
	Then sHCP Form is in edit mode
	When I fill in HCP Coordinator Section as <hcpcoord>
	Then HCP Coordinator Section is filled with <hcpcoord>
	When User clicks Save button
	Then sHCP Form is in view mode
	And I write down form ID
	When I click Logout Link
	Then I am logged out
	When I log in as HCPCoordinator
	And User searches for existing sHCP form and opens it
	Then sHCP Form is in view mode
	When User adds iHCP_04 as Agency contributor supporting role
	Then User iHCP_04 is added as Agency contributor supporting role
	When User clicks Edit button
	Then sHCP Form is in edit mode
	When I fill in Line Manager as <linemanager>
	Then Line Manager section is filled as <linemanager>
	When User clicks Save button
	Then sHCP Form is in view mode
	When I click Logout Link
	Then I am logged out
	When I log in as agencyContributor
	And User searches for existing sHCP form and opens it
	Then sHCP Form is in view mode
	When User clicks Edit button
	Then sHCP Form is in edit mode
	When I fill in Healthcare Professional Details
		| <hcpcountry> | <hcpfirstname> | <hcplastname> |
	Then Healthcare Professional Details is filled
		| <hcpcountry> | <hcpfirstname> | <hcplastname> |
	When I fill in Product Information with following data:
		| <therapeuticarea>	| <productbrandmolecule> | <indication>	| <protocolnumber>	|
	Then Product Information is filled correctly
		| <therapeuticarea>	| <productbrandmolecule> | <indication>	| <protocolnumber>	|
	When I fill in Engagement Description with following data:
		| <engagementtitle>	| <congress>	| <engagementtype> | <alldayengagement> | <engagementvenue> | <engagementcity>	| <engagementcountry>	| <engagementstateprovince> | <scimedbusneeds>	| <engagementobjective>	| <contractedservice>	| <description>	|
	Then Engagement Description is filled correctly
		| <engagementtitle>	| <congress>	| <engagementtype> | <alldayengagement> | <engagementvenue> | <engagementcity>	| <engagementcountry>	| <engagementstateprovince> | <scimedbusneeds>	| <engagementobjective>	| <contractedservice>	| <description>	|
	When I fill in Affiliate Contact as <affcontact>
	Then Affiliate Contact is filled as <affcontact>
	When I fill in HCP Role with following data:
		| <hcproleselect>	| <rationalforhcp>	|  <areaofexpertise> |
	Then HCP Role is filled correctly
		| <hcproleselect>	| <rationalforhcp>	|  <areaofexpertise> |
	When I fill in Fee for Service with following data:
		| <nofee>	| <totalactivitytime> | <preptime> | <hourlyrate> | <flatrate> | <totaldisturbancefee> | <currency> |
	Then Fee for Service is filled correctly
		| <nofee>	| <totalactivitytime> | <preptime> | <hourlyrate> | <flatrate> | <totaldisturbancefee> | <currency> |
	When I fill in Accomodation Description with following data:
		| <noaccomodation>	| <accnametolookup> | <acccostspernight> | <accnrofnights> | <acccurrency> | <accdescription> |
	Then Accomodation Description is filled correctly
		| <noaccomodation>	| <accnametolookup> | <acccostspernight> | <accnrofnights> | <acccurrency> | <accdescription> |
	When I fill in Meal Description with following data:
		| <nomeal>	| <mealtype> | <mealestcosts> | <numberofmeals> | <mealcurrency> | <mealrestaurantname> | <mealcomments> | <breakfastin> |
	Then Meal Description is filled correctly
		| <nomeal>	| <mealtype> | <mealestcosts> | <numberofmeals> | <mealcurrency> | <mealrestaurantname> | <mealcomments> | <breakfastin> |
	When I fill in Travel Details with following data:
		| <notravel> | <traveltype> | <travelcategory> | <travelestcosts> | <travelcurrency> | <traveldescription> |
	Then Travel Details is filled correctly
		| <notravel> | <traveltype> | <travelcategory> | <travelestcosts> | <travelcurrency> | <traveldescription> |
	When I fill in Other Costs with following data:
		| <noothercosts> | <othcoststype> | <othcostsamount> | <othcostscurrency> | <othcostscomment> |
	Then Other Costs is filled correctly
		| <noothercosts> | <othcoststype> | <othcostsamount> | <othcostscurrency> | <othcostscomment> |
	When I fill in Local Requirements with following data:
		| <localreqfull> | <locreqsubmit> | <locreqspecify> | 
	Then Local Requirements is filled correctly
		| <localreqfull> | <locreqsubmit> | <locreqspecify> |
	When I click Save Form Button
	Then sHCP Form is in view mode
	When User clicks Send updated form Button
	Then sHCP Form is in view mode
	When I click Logout Link
	Then I am logged out
	When I log in as HCPCoordinator
	And User searches for existing sHCP form and opens it
	Then sHCP Form is in view mode
	When User adds iHCP_05 as Reader supporting role
	Then User iHCP_05 is added as Reader supporting role
	And New sHCP form is verified
		| <engownername> | <globalfunction>	| <jobtitle> | <engagementpaidby> | <function> | <hcpcoord> | <linemanager> | <hcpcountry> | <hcpfirstname> | <hcplastname> | <therapeuticarea>	| <productbrandmolecule> | <indication>	| <protocolnumber> | <engagementtitle>	| <congress>	| <engagementtype> | <alldayengagement> | <engagementvenue> | <engagementcity>	| <engagementcountry>	| <engagementstateprovince> | <scimedbusneeds>	| <engagementobjective>	| <contractedservice>	| <description>	| <affcontact> | <hcproleselect> | <rationalforhcp>	|  <areaofexpertise> | <nofee>	| <totalactivitytime> | <preptime> | <hourlyrate> | <flatrate> | <totaldisturbancefee> | <currency> | <noaccomodation>	| <accnametolookup> | <acccostspernight> | <accnrofnights> | <acccurrency> | <accdescription> | <nomeal> | <mealtype> | <mealestcosts> | <numberofmeals> | <mealcurrency> | <mealrestaurantname> | <mealcomments> | <breakfastin> | <notravel> | <traveltype> | <travelcategory> | <travelestcosts> | <travelcurrency> | <traveldescription> | <noothercosts> | <othcoststype> | <othcostsamount> | <othcostscurrency> | <othcostscomment> | <localreqfull> | <locreqsubmit> | <locreqspecify> |
	When I click Logout Link
	Then I am logged out

Examples:
| engownername | globalfunction | jobtitle | engagementpaidby | function | hcpcoord | linemanager | hcpcountry | hcpfirstname | hcplastname | therapeuticarea  | productbrandmolecule | indication | protocolnumber | engagementtitle | congress | engagementtype | alldayengagement | engagementvenue | engagementcity | engagementcountry | engagementstateprovince | scimedbusneeds | engagementobjective | contractedservice | description | affcontact           | hcproleselect | rationalforhcp       | areaofexpertise | nofee | totalactivitytime | preptime | hourlyrate | flatrate | totaldisturbancefee | currency | noaccomodation | accnametolookup | acccostspernight | accnrofnights | acccurrency | accdescription     | nomeal | mealtype | mealestcosts | numberofmeals | mealcurrency | mealrestaurantname     | mealcomments        | breakfastin | notravel | traveltype | travelcategory | travelestcosts | travelcurrency | traveldescription         | noothercosts | othcoststype | othcostsamount | othcostscurrency | othcostscomment | localreqfull | locreqsubmit   | locreqspecify | scenarioID |
| iHCP_01      | Yes            | JobTitle | GPS              | GPS      | iHCP_02  | iHCP_03     | US         | john         | kennedy     | CardioMetabolism | Actemra              | Anemia     | 1234567        | someTitle       | AAN      | Consulting     | No               | optional        | Poznan         | US                | Georgia                 | optional       | optional            | No                | optional    | iHCP 04 Test User 04 | Consultant    | Guidelines Expertise | optional        | No    | 10.05             | 10.00    | 10.00      | 0.00     | 10.00               | ALL(Lek) | No             | sdf             | 5.55             | 7             | ALL(Lek)    | sample description | No     | Dinner   | 5.23         | 7             | ALL(Lek)     | sample restaurant name | sample meal comment | No          | No       | Flight     | Business       | 555.23         | ALL(Lek)       | sample travel description | No           | 123          | 555.05         | ALL(Lek)         | sample comment  | Yes          | yes            | Description   | ^ID40      |

##########################################################################################

@US_mHCP
Scenario Outline: 01.mHCP_creation_US
	When I clicked New Form button
	Then mHCP Form option is visible
	When I select mHCP option
	And I click Next button
	Then New mHCP Form opens
	When I fill in Engagement Owner Details with following data:
		| <engownername> | <globalfunction>	| <jobtitle> | <engagementpaidby> | <function> |
	Then Engagement Owner Details is filled correctly
		| <engownername> | <globalfunction>	| <jobtitle> | <engagementpaidby> | <function> |
	When User clicks Save button
	And History Section has Created record
	Then mHCP Form is in view mode
	When User clicks Edit button
	Then mHCP Form is in edit mode
	When I fill in HCP Coordinator Section as <hcpcoord>
	Then HCP Coordinator Section is filled with <hcpcoord>
	When I fill in Line Manager as <linemanager>
	Then Line Manager section is filled as <linemanager>
	When I create new Healthcare Professional Details
		| <hcpcountry> | <hcpfirstname> | <hcplastname> | <hcpspeciality> | <hcpstateofpractice> | <hcpaddress> | <hcpzipcode> | <hcpcityname> |
	Then Healthcare Professional Details is filled
		| <hcpcountry> | <hcpfirstname> | <hcplastname> |
	When I fill in Product Information with following data:
		| <therapeuticarea>	| <productbrandmolecule> | <indication>	| <protocolnumber>	|
	Then Product Information is filled correctly
		| <therapeuticarea>	| <productbrandmolecule> | <indication>	| <protocolnumber>	|
	When I fill in Engagement Description with following data:
		| <engagementtitle>	| <congress>	| <engagementtype> | <alldayengagement> | <engagementvenue> | <engagementcity>	| <engagementcountry>	| <engagementstateprovince> | <scimedbusneeds>	| <engagementobjective>	| <contractedservice>	| <description>	|
	Then Engagement Description is filled correctly
		| <engagementtitle>	| <congress>	| <engagementtype> | <alldayengagement> | <engagementvenue> | <engagementcity>	| <engagementcountry>	| <engagementstateprovince> | <scimedbusneeds>	| <engagementobjective>	| <contractedservice>	| <description>	|
	When I fill in Affiliate Contact as <affcontact>
	Then Affiliate Contact is filled as <affcontact>
	When I fill in HCP Role with following data:
		| <hcproleselect>	| <rationalforhcp>	|  <areaofexpertise> |
	Then HCP Role is filled correctly
		| <hcproleselect>	| <rationalforhcp>	|  <areaofexpertise> |
	When I fill in Fee for Service with following data:
		| <nofee>	| <totalactivitytime> | <preptime> | <hourlyrate> | <flatrate> | <totaldisturbancefee> | <currency> |
	Then Fee for Service is filled correctly
		| <nofee>	| <totalactivitytime> | <preptime> | <hourlyrate> | <flatrate> | <totaldisturbancefee> | <currency> |
	When I fill in Accomodation Description with following data:
		| <noaccomodation>	| <accnametolookup> | <acccostspernight> | <accnrofnights> | <acccurrency> | <accdescription> |
	Then Accomodation Description is filled correctly
		| <noaccomodation>	| <accnametolookup> | <acccostspernight> | <accnrofnights> | <acccurrency> | <accdescription> |
	When I fill in Meal Description with following data:
		| <nomeal>	| <mealtype> | <mealestcosts> | <numberofmeals> | <mealcurrency> | <mealrestaurantname> | <mealcomments> | <breakfastin> |
	Then Meal Description is filled correctly
		| <nomeal>	| <mealtype> | <mealestcosts> | <numberofmeals> | <mealcurrency> | <mealrestaurantname> | <mealcomments> | <breakfastin> |
	When I fill in Travel Details with following data:
		| <notravel> | <traveltype> | <travelcategory> | <travelestcosts> | <travelcurrency> | <traveldescription> |
	Then Travel Details is filled correctly
		| <notravel> | <traveltype> | <travelcategory> | <travelestcosts> | <travelcurrency> | <traveldescription> |
	When I fill in Other Costs with following data:
		| <noothercosts> | <othcoststype> | <othcostsamount> | <othcostscurrency> | <othcostscomment> |
	Then Other Costs is filled correctly
		| <noothercosts> | <othcoststype> | <othcostsamount> | <othcostscurrency> | <othcostscomment> |
	When I fill in Local Requirements with following data:
		| <localreqfull> | <locreqsubmit> | <locreqspecify> |
	Then Local Requirements is filled correctly
		| <localreqfull> | <locreqsubmit> | <locreqspecify> |
	When I click Save Form Button
	Then mHCP Form is in view mode
	And I write down form ID
	And New mHCP form is verified
		| <engownername> | <globalfunction>	| <jobtitle> | <engagementpaidby> | <function> | <hcpcoord> | <linemanager> | <hcpcountry> | <hcpfirstname> | <hcplastname> | <hcpfirstname2> | <hcplastname2> | <therapeuticarea>	| <productbrandmolecule> | <indication>	| <protocolnumber> | <engagementtitle>	| <congress>	| <engagementtype> | <alldayengagement> | <engagementvenue> | <engagementcity>	| <engagementcountry>	| <engagementstateprovince> | <scimedbusneeds>	| <engagementobjective>	| <contractedservice>	| <description>	| <affcontact> | <hcproleselect> | <rationalforhcp>	|  <areaofexpertise> | <nofee>	| <totalactivitytime> | <preptime> | <hourlyrate> | <flatrate> | <totaldisturbancefee> | <currency> | <noaccomodation>	| <accnametolookup> | <acccostspernight> | <accnrofnights> | <acccurrency> | <accdescription> | <nomeal> | <mealtype> | <mealestcosts> | <numberofmeals> | <mealcurrency> | <mealrestaurantname> | <mealcomments> | <breakfastin> | <notravel> | <traveltype> | <travelcategory> | <travelestcosts> | <travelcurrency> | <traveldescription> | <noothercosts> | <othcoststype> | <othcostsamount> | <othcostscurrency> | <othcostscomment> | <localreqfull> | <locreqsubmit> | <locreqspecify> |
	When I click Logout Link
	Then I am logged out

Examples:
| engownername | globalfunction | jobtitle | engagementpaidby | function | hcpcoord | linemanager | hcpcountry | hcpfirstname | hcplastname | hcpspeciality | hcpstateofpractice | hcpaddress | hcpzipcode | hcpcityname | therapeuticarea  | productbrandmolecule | indication | protocolnumber | engagementtitle | congress | engagementtype | alldayengagement | engagementvenue | engagementcity | engagementcountry | engagementstateprovince | scimedbusneeds | engagementobjective | contractedservice | description | affcontact           | hcproleselect | rationalforhcp       | areaofexpertise | nofee | totalactivitytime | preptime | hourlyrate | flatrate | totaldisturbancefee | currency | noaccomodation | accnametolookup | acccostspernight | accnrofnights | acccurrency | accdescription     | nomeal | mealtype | mealestcosts | numberofmeals | mealcurrency | mealrestaurantname     | mealcomments        | breakfastin | notravel | traveltype | travelcategory | travelestcosts | travelcurrency | traveldescription         | noothercosts | othcoststype | othcostsamount | othcostscurrency | othcostscomment | localreqfull | locreqsubmit | locreqspecify | scenarioID |
| selectMe     | No             | JobTitle | GPS              | GPS      | iHCP_02  | iHCP_03     | US         | adam         | kernedy     | Addiction     | Alabama            | 1234567    | 456321     | SomeCity    | CardioMetabolism | Actemra              | Anemia     | 1234567        | someTitle       | AAN      | Consulting     | Yes              | optional        | Poznan         | US                | Georgia                 | optional       | optional            | No                | optional    | iHCP 04 Test User 04 | Consultant    | Guidelines Expertise | optional        | No    | 10.05             | 10.00    | 10.00      | 0.00     | 10.00               | ALL(Lek) | Yes            | sdf             | 5.55             | 7             | ALL(Lek)    | sample description | Yes    | Dinner   | 5.23         | 7             | ALL(Lek)     | sample restaurant name | sample meal comment | No          | No       | Flight     | Business       | 555.23         | ALL(Lek)       | sample travel description | No           | 123          | 555.05         | ALL(Lek)         | sample comment  | Yes          | yes          | Description   | ^ID50      |

##########################################################################################