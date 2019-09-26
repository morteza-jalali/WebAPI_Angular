import { Component, OnInit } from '@angular/core';
import { CourseService } from '../../shared/course.service';
import { NgForm } from '@angular/forms';
import { Course } from '../../shared/course.model';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit {

    constructor(private service: CourseService) { }

 
   ngOnInit() {
    this.resetForm();
  }
  
	resetForm(form?: NgForm) {
		if (form != null)
		  form.resetForm();
		this.service.formData = {
		  ID: null,
		  Name: '',
		  StartDate: '',
		  EndDate: ''
		}
	 }
  
  onSubmit(form: NgForm) {

	if(!confirm('Save the new course details?'))
		return;

    if (form.value.ID == null)
      this.insertRecord(form);
	  
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
	//console.log(form.value);  
	  this.service.postCourse(form.value).subscribe(res => {
		  if(!(res instanceof Object))
		  {
			   var obj = jQuery.parseJSON( res );
			   if(obj.err ="true")
					alert(obj.msg);
			   
			   return;
		  }
		  		 
		  console.log('Inserted Successfully');
		  this.resetForm(form);
		});

  }

  updateRecord(form: NgForm) {
    this.service.putCourse(form.value).subscribe(res => {
      this.resetForm(form);
    });

  }

}
