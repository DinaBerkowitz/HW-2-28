﻿

$(() => {
    let count = 1;

    $("#add-rows").on('click', function () {
       
        $("#ppl-rows").append(` <div class="row" style="margin-bottom: 10px;">
         <div class="col-md-4"><input class="form-control" type="text" name="people[${count}].firstName" placeholder="First Name" /></div>
        <div class="col-md-4"><input class="form-control" type="text" name="people[${count}].lastName" placeholder="Last Name" /></div>
        <div class="col-md-4"><input class="form-control" type="text" name="people[${count}].age" placeholder="Age" /></div></div>`);
        count++;
    })
   
})

