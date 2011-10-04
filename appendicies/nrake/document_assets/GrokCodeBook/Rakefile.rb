require 'rake/clean'
require 'rake/tasklib'
require 'albacore'

NUNIT_EXE = "C:/Program Files (x86)/NUnit 2.5.10/bin/net-2.0/nunit-console.exe"
PROJECTS_DIR = "code/MessageN/projects" 
LIB_DIR = "code/MessageN/lib"
OUTPUT_DIR = "build" 
MESSAGEN_DIR = "code/MessageN/projects/MessageN" 
MESSAGEN_TEST_DIR = "code/MessageN/projects/MessageN.Test" 

CLEAN.include("#{OUTPUT_DIR}")

task :default => "build:all"
 
namespace :build do
    
    task :all => 
        [:clean, :copy, :compile_core, 
            :compile_core_tests, :test]

    desc "Copy lib DLLs to output directory"
    task :copy do
        cp "#{LIB_DIR}", "#{OUTPUT_DIR}"
    end
  
    # You may have to update the Albacore gem using 
    # "igem.exe update albacore" to get the csc task
    desc "Compile core library using C# Compiler"
    csc :compile_core do |csc|
        csc.compile FileList["#{MESSAGEN_DIR}/**/*.cs"]
        csc.output = "#{OUTPUT_DIR}/MessageN.dll"
        csc.references FileList["#{OUTPUT_DIR}/*.dll"]
        csc.target = :library
    end
  
    desc "Compile core library test suite using C# Compiler"
    csc :compile_core_tests do |csc|
        csc.compile FileList["#{MESSAGEN_TEST_DIR}/**/*.cs"]
        csc.output = "#{MESSAGEN_TEST_DIR}/bin/MessageN.Test.dll"
        csc.references FileList["#{OUTPUT_DIR}/*.dll"]
        csc.target = :library
    end
  
    desc "Runs tests with NUnit"
    nunit :test=>
        [:clean, :copy, :compile_core, :compile_core_tests] 
    do |nunit|
        nunit.command = NUNIT_EXE
        nunit.assemblies FileList["#{OUTPUT_DIR}/*.Test.dll"]
        nunit.options << "/xml=TestResults.xml" << "/nologo"
    end

end

