import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { CoursesComponent } from './courses/courses.component';
import { CourseComponent } from './Courses/course/course.component';
import { CourseService } from './shared/course.service';

@NgModule({
    declarations: [
        AppComponent,
        CoursesComponent,
        CourseComponent
    ],
    imports: [
        BrowserModule,
		FormsModule,
		HttpClientModule,
		NgbModule
    ],
    providers: [CourseService],
    bootstrap: [AppComponent]
})
export class AppModule { }
