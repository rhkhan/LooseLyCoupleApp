app.controller("appointmentController", function ($scope, viewModelHelper, appointmentFactory, $uibModal, models, appointmentValidator) {

    loadAppointments();
    $scope.hasModelErrors = false;
    $scope.mAppoint = {};
    
    $scope.appointmentTypes = [
        { appointmentID: "1", appointmentName: "General" },
        { appointmentID:"2",appointmentName:"Emergency"}
    ]
    $scope.mAppoint.appType = "0";//$scope.appointmentTypes[0].appointmentID.toString();




    var count=1;
    $scope.addRows = function () {
        count++;
        var r = "<tr><td><input type='text' id='a" + count + "'/></td><td><input type='text' id='b" + count + "'/></td>"+
            "<td><input type='button' id='remove" + count + "' class='removebtn btn btn-sm' value='Remove'</td></tr>";
        $("#addMoreTable").append(r);

        $("#addMoreTable").on('click','.removebtn',function () {
            $(this).parent().parent().remove();
        });
       // alert("h");
    }



    //### TEST DATA ####
    $scope.companies = [
                        {
                            'name': 'Infosys Technologies',
                            'employees': 125000,
                            'headoffice': 'Bangalore'
                        },
                    	{
                    	    'name': 'Cognizant Technologies',
                    	    'employees': 100000,
                    	    'headoffice': 'Bangalore'
                    	},
	                    {
	                    	'name': 'Wipro',
	                    	'employees': 115000,
	                    	'headoffice': 'Bangalore'
	                    },
		                {
		                    'name': 'Tata Consultancy Services (TCS)',
		                    'employees': 150000,
		                    'headoffice': 'Bangalore'
		                },
			            {
			               'name': 'HCL Technologies',
			               'employees': 90000,
			               'headoffice': 'Noida'
			            },
                     ];
  

    $scope.addRow = function(){		
        $scope.companies.push({ 'name':$scope.name, 'employees': $scope.employees, 'headoffice':$scope.headoffice });
        $scope.name='';
        $scope.employees='';
        $scope.headoffice='';
    };

    $scope.removeRow = function(name){				
        var index = -1;		
        var comArr = eval( $scope.companies );
        for( var i = 0; i < comArr.length; i++ ) {
            if( comArr[i].name === name ) {
                index = i;
                break;
            }
        }
        if( index === -1 ) {
            alert( "Something gone wrong" );
        }
        $scope.companies.splice( index, 1 );		
    };

    $scope.removeR = function ($index) {
        $scope.companies.splice($index, 1);
    }

    //#########################

    $scope.submitForm = function () {
        //alert("dsd");

        var appoint = new models.appointments($scope.mAppoint);
        $scope.valResult = {};
        //alert($scope.mAppoint.PatientName);
        var appointValidatiorWatch = $scope.$watch(
            function () {
                return appoint;
            },
            function () {
                $scope.valResult = appointmentValidator.validate(appoint);
                if (appoint.$isValid) {
                    var promisePost = appointmentFactory.saveAppointment($scope.mAppoint)
                    .success(function (data) {
                        viewModelHelper.navigateTo('Appointment/List');
                    })
                    .error(function (error) {
                        var strmsg = JSON.stringify(error.ModelState);
                        alert(strmsg);
                        /*spliting the errors*/
                        var resSubstring = strmsg.substring(strmsg.indexOf("[") + 1, strmsg.indexOf("]"));
                        var arrString = resSubstring.split(",");
                        var g = "";
                        for (var i = 0; i < arrString.length; i++)
                            g += arrString[i] + "<br/>";
                        $scope.error = g;
                        /* End Spliting*/

                        $scope.hasModelErrors = true;
                    });
                    appointValidatiorWatch();
                }
            }, true);
    }

    function loadAppointments()
    {
        appointmentFactory.getAppointments()
      .success(function (appointData) {
          $scope.appointList = appointData;
      })
      .error(function () {
          $scope.status = 'Unable to load appointment list' + error.message;
      })
    }

    $scope.initAppointment = function () {
        loadAppointments();
    }

});

app.controller('appointmentEditController', function ($scope, $routeParams, appointmentFactory, viewModelHelper) {

    //$scope.appointId = $routeParams.appointID;
    $scope.mAppoint = {};
    appointmentFactory.getAppointmentById($routeParams.appointID)
    .success(function (ap) {
        $scope.mAppoint.Id = ap.Id;
        $scope.mAppoint.PatientName = ap.PatientName;
        $scope.mAppoint.Phone = ap.Phone;
        $scope.mAppoint.appType = ap.appType;
        $scope.mAppoint.appID = ap.appID;
        $scope.mAppoint.SI = ap.SI;
        $scope.mAppoint.appDate = ap.appDate;
    })
    .error(function (error) {
        $scope.status = "unable to load appointment data: " + error.message;
    });

    $scope.updateAppointment = function () {

        var promise = appointmentFactory.updateApp($scope.mAppoint);
        viewModelHelper.navigateTo('Appointment/List');

        //#######################
        //var appoint = new models.appointments($scope.mAppoint);
        //$scope.valResult = {};
        //var appointValidatiorWatch = $scope.$watch(
        //    function () {
        //        return appoint;
        //    },
        //    function () {
        //        $scope.valResult = appointmentValidator.validate(appoint);
        //        if (appoint.$isValid) {
        //            var promisePost = appointmentFactory.saveAppointment($scope.mAppoint)
        //            .success(function (data) {
        //                viewModelHelper.navigateTo('Appointment/List');
        //            })
        //            .error(function (error) {
        //                var strmsg = JSON.stringify(error.ModelState);
        //                //alert(strmsg);
        //                /*spliting the errors*/
        //                var resSubstring = strmsg.substring(strmsg.indexOf("[") + 1, strmsg.indexOf("]"));
        //                var arrString = resSubstring.split(",");
        //                var g = "";
        //                for (var i = 0; i < arrString.length; i++)
        //                    g += arrString[i] + "<br/>";
        //                $scope.error = g;
        //                /* End Spliting*/
        //                $scope.hasModelErrors = true;
        //            });
        //            appointValidatiorWatch();
        //        }
        //    }, true);
        //#######################

    }

});