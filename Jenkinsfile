pipeline {
    agent { label 'windows' }

    environment {
        SOLUTION_NAME = "MySolution.sln"
        TEST_DLL = "MyApp.Tests\\bin\\Debug\\MyApp.Tests.dll"
        GIT_REPO = "https://github.com/epam/your-repo.git"
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: "${GIT_REPO}"
            }
        }

        stage('Restore Packages') {
            steps {
                bat "nuget restore ${SOLUTION_NAME}"
            }
        }

        stage('Build Solution') {
            steps {
                bat "\"C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\BuildTools\\MSBuild\\Current\\Bin\\MSBuild.exe\" ${SOLUTION_NAME} /p:Configuration=Debug"
            }
        }

        stage('Run Regression Tests') {
            steps {
                bat "\"C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Community\\Common7\\IDE\\CommonExtensions\\Microsoft\\TestWindow\\vstest.console.exe\" ${TEST_DLL} --TestCaseFilter:TestCategory=Regression /logger:trx"
            }
        }

        stage('Publish Results') {
            steps {
                mstest testResultsFile:"**/*.trx"
            }
        }
    }
}
