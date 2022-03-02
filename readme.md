# WorkHours

The objective of this project is to calculate the payments of employees depending on the hours they have worked.
The main classes are:
- **Payments**. Processes the input text file. Calls the payment calculation for each entry in the file.
- **WorkEntry**. Represents each entry of the input file.
- **WorkInterval**. Each interval in a WorkEntry.
- **Hour Rates**. Allows to define the work schedule and hour rates.
## Calculation
For each interval found in the input file for an employee we look for all the hour rates that it includes and we calculate each of those partial time spans applying the corresponding rates.
