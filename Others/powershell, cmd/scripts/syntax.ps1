function Separator
{
    param($number)
    $separator = "----------------------------------------------------------"
    Write-Host $("[$number] $separator")
}

# Write into console
Write-Host "Hello scumbag!" -NoNewline
Write-Host " You are a scumbag!"
Write-Host "Yeah"


Separator 1


# pipe commands command1 | command2
# write a text into a file
"Some text" | Out-File myFile.txt

# create just empty file
Out-File "myEmptyFile1.cpp"

# another way how to create file
New-Item -Path "myEmptyFile2.cpp" -ItemType "file" -Value "This will be written in"
New-Item -Path "myfolder" -ItemType "directory"

# copy file
Copy-Item -Path "myEmptyFile2.cpp" -Destination "myfolder/myCopyEmptyFile2.cpp"

# move file
New-Item -Path "myfolder/fileToBeMoved.txt" -ItemType "file"
Move-Item -Path "myfolder/fileToBeMoved.txt" -Destination "fileToBeMoved.txt"

# rename file
Rename-Item -Path "fileToBeMoved.txt" -NewName "fileRenamed.txt"

# remove file
Remove-Item -Path "fileRenamed.txt"
Remove-Item -Path "myfolder" -Recurse
Remove-Item -Path "myEmptyFile1.cpp"
Remove-Item -Path "myEmptyFile2.cpp"

# test path
Write-Host "Does path exist: $(Test-Path -Path 'myEmptyFile1.cpp')"


Separator 2


# variables
$myVariable = "This is a string variable"
Write-Host $myVariable


Separator 3


# types
$myString = "This is a string"
$myInt = 5
$myFloat = 5.5
$myBool = $true
$myArray = @("one", "two", "three")
$myHash = @{ "key1" = "value1"; "key2" = "value2" }

Write-Host "Data types:"
Write-Host $myInt
Write-Host $myFloat
Write-Host $myBool
Write-Host $myArray
Write-Host $myHash

Write-Host $myBool.GetType()
# it is not type safe:
$myBool = 100
Write-Host $myBool.GetType()


Separator 4


# arithmetic
$number1 = 5
$number2 = 10
$sum = $number1 + $number2
Write-Host "Sum: $sum"


Separator 5


# properties
# since everything is an object, you can call properties like Length
Write-Host "Property length: $( $myString.Length )"


# methods
# below you can list all methods of a string object
# actually it would be better if you just run the command
#  directly from powershell console, because there it prints it
#  in a more readable way.
#Write-Host "$(Get-Member -InputObject $myString)"


Separator 6


# arrays
$myArray = @("one", "two", "three")
Write-Host $myArray[2] # indexed from 0
$myArray += "four" # add element
Write-Host $myArray


Separator 7


# dictionaries
$myDict = @{ "Hello" = "Ahoj"; "Goodbye" = "Sbohem" }
Write-Host $myDict["Hello"]
$myDict["Goodbye"] = "Nashledanou"
Write-Host $myDict["Goodbye"]
$myDict["Thank you"] = "Děkuji" # add new key
$myDict.Add("Please", "Prosím") # add new key
Write-Host $myDict.Count
$myDict.Remove("Please") # remove key


Separator 8


# user input
$myInput = Read-Host "Enter something: "
Write-Host "You entered: $myInput"


Separator 9


# conditions
$number1 = 5
$number2 = 10

if ($number1 -gt $number2)
{
    Write-Host "$number1 is greater than $number2"
}
elseif ($number1 -lt $number2)
{
    Write-Host "$number1 is less than $number2"
}
elseif ($number1 -eq $number2)
{
    Write-Host "$number1 is equal to $number2"
}
else
{
    Write-Host "$number1 is not equal to $number2"
}

if ($number1 -eq 5 -and $number2 -eq 10)
{
    Write-Host "Both numbers are correct"
}

Separator 10


# switch

$fruit = "apple"

switch ($fruit)
{
    "apple"
    {
        Write-Host "It is an apple"
    }
    "banana"
    {
        Write-Host "It is a banana"
    }
    "orange"
    {
        Write-Host "It is an orange"
    }
    default
    {
        Write-Host "It is something else"
    }
}


Separator 11


# loops
# for loop
for ($i = 0; $i -lt 5; $i++)
{
    Write-Host $i
}

$i = 0;
while ($i -lt 5)
{
    Write-Host $i
    $i++
}

foreach ($item in $myArray)
{
    Write-Host $item
}

$i = 0
do {
    Write-Host $i
    $i++
} while ($i -lt 5)


Separator 12


# functions
function MyFunction
{
    Write-Host "This is a function"
}

MyFunction # call the function

function Add-Numbers
{
    param($number1, $number2) # function parameters
    return $number1 + $number2 # return statement
}

Write-Host "Sum: $(Add-Numbers 5 10)"


Separator 13


# error handling
try
{
    1 / 0
}
catch [System.DivideByZeroException]
{
    Write-Host "Division by zero"
}
catch
{
    Write-Host "Some other error"
}
finally
{
    Write-Host "This will always be executed"
}

# uncoment below to see the error 1 or error 2
# throw "This is an error 1"
# Write-Error "This is an error 2"


Separator 14


# object oriented programming
class Person
{
    [string]$name
    [int]$age

    Person([string]$name, [int]$age)
    {
        $this.name = $name
        $this.age = $age
    }

    [string] GetInfo()
    {
        return "$($this.name) is $($this.age) years old"
    }
}

$person1 = [Person]::new("John", 30)
$person2 = [Person]::new("Jane", 25)

Write-Host $person1.GetInfo()
Write-Host $person2.GetInfo()
Write-Host $person1.name


