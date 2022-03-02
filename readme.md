
# WorkHours

The objective of this project is to calculate the payments of employees depending on the hours they have worked.
The main classes are:
- **Payments**. Processes the input text file. Calls the payment calculation for each entry in the file.
- **WorkEntry**. Represents each entry of the input file.
- **WorkInterval**. Each interval in a WorkEntry.
- **Hour Rates**. Allows to define the work schedule and hour rates.

## Calculation
For each interval found in the input file for an employee we look for all the hour rates that it includes and we calculate each of those partial time spans applying the corresponding rates.

## Conditions
The input text file should be in this path and filename:

    C:\inputfiles\input.txt

## Samples
Input file:

    RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00
    ASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00

Output:

    Starting process...
    Processing input file and calculating payments...
    The amount to pay RENE is: 215.00 USD
    The amount to pay ASTRID is: 85.00 USD
## Tests
### ParseNewEntry
Checks if the parsing process is correct

### Calculate
Performs a calculation with a sample work entry