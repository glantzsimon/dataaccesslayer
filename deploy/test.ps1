$testFile = ".\DataAccess.Tests\bin\Release\K9.DataAccessLayer.Tests.dll"
	
function ProcessErrors(){
  if($? -eq $false)
  {
    throw "The previous command failed (see above)";
  }
}

function _Test() {
  echo "Running tests"
  
  c:\xunit\runner\xunit.console.exe $testFile
  ProcessErrors
}

function Main {
  Try {
	_Test
  }
  Catch {
    Write-Error $_.Exception
    exit 1
  }
}

Main