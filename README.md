# WeeBits Computer Component Supply Service

The WeeBits Computer Component Supply Service is an established computer component
wholesale supplier of high-quality computer components for both the computer trade and 
consumers. The WeeBits Computer Component Supply Service has warehouses in Glasgow
and Edinburgh but plans to expand into Manchester (England), Newcastle (England), Calais
(France), and Le Harve (France). You are tasked with constructing an information 
management system to support their business plan. User roles are Customer, Manager, and 
Sales Staff. Minimum requirements are set out below:

## Human Resource System (<b><a href="https://weebits.azurewebsites.net" target="_blank">Live Demo on Azure</b></a>)
The Manager shall be able to:
- Add a new employee record that shows name etc.
- View (and print) the set of current employees in total and by regional delivery 
- View (and print) number of employees in different age and gender categories
- View (and print) average rates of pay per role and per gender
- Present absentee profile by different job categories.
- View and (print) annual staff turnover ratios in total and by regional delivery service
<br>
<br>
<table border="1" cellpadding="0" cellspacing="0" style="width:929px;" width="929">
	<thead>
		<tr>
			<th colspan="6" style="width:929px;height:20px;"><p align="center"><strong>Human Resource System User Stories</strong></p>
			</th>
		</tr>
		<tr>
			<th style="width:82px;height:20px;"><p align="center"><strong>#</strong></p>
			</th>
			<th style="width:96px;height:20px;"><p align="center"><strong>Theme</strong></p>
			</th>
			<th style="width:81px;height:20px;"><p align="center"><strong>Role</strong></p>
			</th>
			<th style="width:253px;height:20px;"><p align="center"><strong>Action</strong></p>
			</th>
			<th style="width:386px;height:20px;"><p align="center"><strong>Goal</strong></p>
			</th>
			<th style="width:32px;height:20px;"><p></p>
			</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td style="width:82px;height:36px;"><p>HR.US001</p>
			</td>
			<td rowspan="7" style="width:96px;height:36px;"><p align="center">Login System</p>
			</td>
			<td style="width:81px;height:36px;"><p>As a manager</p>
			</td>
			<td style="width:253px;height:36px;"><p>I want to have a unique username</p>
			</td>
			<td style="width:386px;height:36px;"><p>To log into the system</p>
			</td>
			<td style="width:32px;height:36px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US002</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I want to have a password</p>
			</td>
			<td style="width:386px;"><p>To log into the system</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US003</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I want to have a secure login screen with username and password fields</p>
			</td>
			<td style="width:386px;"><p>To enter my unique login credential</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US003</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I want a button on the secure login screen</p>
			</td>
			<td style="width:386px;"><p>To submitmycredentials and access restricted content</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US004</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I want the ability to log out of the system</p>
			</td>
			<td style="width:386px;"><p>To end my session and prevent system misuse</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US005</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I want human resource system to be role restricted</p>
			</td>
			<td style="width:386px;"><p>To prevent unauthorised access</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US006</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I want to access human resource system after successful login</p>
			</td>
			<td style="width:386px;"><p>To manage employee data and generate reports</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US007</p>
			</td>
			<td rowspan="6" style="width:96px;"><p align="center">Employee Management</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I want tohave an add employee screen withinput fields</p>
			</td>
			<td style="width:386px;"><p>To enter information for a new employee</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US008</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I want a button on the add employee screen</p>
			</td>
			<td style="width:386px;"><p>To submit the employee data and addthemas a new staff member</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US009</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I want to view a list of all current employees</p>
			</td>
			<td style="width:386px;"><p>To get an overview of currently employed staff</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US010</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I want to print a list of all current employees</p>
			</td>
			<td style="width:386px;"><p>To produce a hardcopy of the employee list</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US011</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I wanted to view a list of current employees for a region</p>
			</td>
			<td style="width:386px;"><p>To access staff information related to a region</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US012</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I wanted to print a list of current employees for a region</p>
			</td>
			<td style="width:386px;"><p>To produce a hardcopy of the region employee list</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US013</p>
			</td>
			<td rowspan="13" style="width:96px;"><p align="center">Reports Management</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I want to view number of employees filtered by age</p>
			</td>
			<td style="width:386px;"><p>To generate employee demographics report</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;height:20px;"><p>HR.US014</p>
			</td>
			<td style="width:81px;height:20px;"><p>As a manager</p>
			</td>
			<td style="width:253px;height:20px;"><p>I want to print number of employees filtered by age</p>
			</td>
			<td style="width:386px;height:20px;"><p>To produce a hardcopy of age group report</p>
			</td>
			<td style="width:32px;height:20px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US015</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I want to view number of employees filtered by gender</p>
			</td>
			<td style="width:386px;"><p>To generate employee demographics report</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US016</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I want to print number of employees filtered by gender</p>
			</td>
			<td style="width:386px;"><p>To produce a hardcopy of gender report</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US017</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I want to view average rates of pay by role</p>
			</td>
			<td style="width:386px;"><p>To compare average payrates across the roles</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US018</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I want to print average rates of pay by role</p>
			</td>
			<td style="width:386px;"><p>To produce a hardcopy of role payrates report</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US01</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I want to view average rates of pay by gender</p>
			</td>
			<td style="width:386px;"><p>To compare average payrates across genders</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US020</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I want to print average rates of pay by gender</p>
			</td>
			<td style="width:386px;"><p>To produce a hardcopy of gender payrates report</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US021</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I want to see absentee profile by job category</p>
			</td>
			<td style="width:386px;"><p>To review absences across different job categories</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US022</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I want to view annual staff turnover ratio for the whole company</p>
			</td>
			<td style="width:386px;"><p>To monitor company-wide employee satisfaction</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US023</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I want to print annual staff turnover ratio for the whole company</p>
			</td>
			<td style="width:386px;"><p>To produce a hardcopy of the staff turnover report</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US024</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I want to view annual staff turnover ratio by region</p>
			</td>
			<td style="width:386px;"><p>To monitor employee satisfaction for a region</p>
			</td>
			<td style="width:32px;"><p align="center">:heavy_check_mark:</p>
			</td>
		</tr>
		<tr>
			<td style="width:82px;"><p>HR.US025</p>
			</td>
			<td style="width:81px;"><p>As a manager</p>
			</td>
			<td style="width:253px;"><p>I want to print annual staff turnover ratio by region</p>
			</td>
			<td style="width:386px;"><p>To produce a hardcopy of the staff turnover report</p>
			</td>
			<td style="width:32px;"><p>:heavy_check_mark:</p>
			</td>
		</tr>
	</tbody>
</table>