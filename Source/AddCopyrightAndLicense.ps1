param($companyname = "Tahoe Regional Planning Agency")

[System.Globalization.CultureInfo] $ci = [System.Globalization.CultureInfo]::GetCurrentCulture

# Header template
$header = "-----------------------------------------------------------------------
<copyright file=""{0}"" company=""{1}"">
Copyright (c) {1}. All rights reserved.
<author>Sitka Technology Group</author>
<date>{2}</date>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------"

function Write-Header ($file, $lastWriteDate)
{
    # Get the file content as as Array object that contains the file lines
    $content = Get-Content $file
    
    # Getting the content as a String
    $contentAsString =  $content | Out-String

    # Splitting the file path and getting the leaf/last part, that is, the file name
    $filename = Split-Path -Leaf $file

    $extension = [System.IO.Path]::GetExtension($filename)
    $commentStart
    $commentEnd
    if($extension -eq ".cs" -or $extension -eq ".js")
    {
        $commentStart = "/*"
        $commentEnd = "*/"
    }
    elseif ($extension -eq ".cshtml")
    {
        $commentStart = "@*"
        $commentEnd = "*@"
    }
    else
    {
        return
    }

    
    <# If content starts with a comment, then the file has a copyright notice already
       Let's Skip the first 21 lines of the copyright notice template... #>
    if($contentAsString.StartsWith($commentStart))
    {
       $content = $content | Select-Object -skip 21
    }
    
    # $fileheader is assigned the value of $header with dynamic values passed as parameters after -f
    $headerWithCommentDelimiter = $commentStart + $header + $commentEnd
    $fileheader = $headerWithCommentDelimiter -f $filename, $companyname, $lastWriteDate

    # Writing the header to the file
    Set-Content $file $fileheader -encoding UTF8

    # Append the content to the file
    Add-Content $file $content
}

#Filter files getting only .cs ones and exclude specific file extensions
svn status | % {
    $fileString = ($_ -split '\s+')[1]
    $fileInfo = ([System.IO.FileInfo]$fileString)
        
    if (($fileInfo.Extension -match "\.(cs|cshtml|js)$") -and ($fileInfo.FullName -notmatch "\\(bin|obj|Content|Generated|Scripts|_Annotations.cs|NuGetPackages)(\\|$)"))
    {
        Write-Host Updating license and copyright header: $fileInfo.FullName
        Write-Header  $fileInfo.FullName $fileInfo.LastWriteTime.ToLongDateString();
    } 
}