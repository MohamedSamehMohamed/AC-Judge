
$(document).ready(function(){
    
});

function Show_User_Error_Message(element){
    var btn = element + " form [type = 'submit']";
    
    $(btn).click(function(){
        var alt = element + " div[id = 'user-error-msg']";
        $(alt).each(function(){
            var Msg = $(this).children('span');
            if(!($(Msg).is(':empty'))){
                $(this).css('display','block');
            }
        });
    });
}

$(function(){
    
    'use strict';
    /* Start User Sign In, Sign Up */;
    Show_User_Error_Message('.user-signin');
    Show_User_Error_Message('.user-signup');
    

   /*x.forEach(function(val){
       
        
    });
    
    /* End User Sign In, Sign Up */
     
});