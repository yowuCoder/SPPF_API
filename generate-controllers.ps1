# Define variables
$modelsDirectory = "Models/COTIOT"
$controllersDirectory = "Controllers/Cotiot"
$dbContextClassName = "CotiotContext"

# Check if both Models and Controllers directories exist
if ( Test-Path $controllersDirectory) {
    # Iterate over each model file in the Models directory
    foreach ($file in Get-ChildItem -Path $modelsDirectory -Filter *.cs) {
        # Get the base name of the model file (without extension)
        $modelClass = $file.BaseName
        # Construct the controller name based on the model class name
        $controllerName = "${modelClass}Controller"
        # Generate controller for the model using the ASP.NET Core code generator
        dotnet aspnet-codegenerator controller -name $controllerName -async -api -m $modelClass -dc $dbContextClassName -outDir $controllersDirectory 
    }
} else {
    # If either Models or Controllers directory does not exist, print a message and exit
    Write-Host "Either Models or Controllers directory does not exist. Script will not continue."
}
