import { Injectable } from '@angular/core';
import { Course } from './course.model';
import { HttpClient } from "@angular/common/http";
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})

export class CourseService {

	readonly rootURL ="https://localhost:44320/api"

    formData: Course;

    constructor(private http : HttpClient) { }
	
	postCourse(formData : Course){
		//console.log(formData);
		return this.http.post(this.rootURL+'/Course',formData).pipe( catchError(this.handleError) );
    }
	
	putCourse(formData : Course){	
		return this.http.put(this.rootURL+'/Course/'+formData.ID,formData);    
   }
   
   private handleError(error: HttpErrorResponse) {
	  if (!(error.error instanceof ErrorEvent)) {
		console.error( 'error code' +error.status + ', error message: ' + error.error.Message);
	  } 
	};
}
