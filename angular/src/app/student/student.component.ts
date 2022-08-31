import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from '@shared/paged-listing-component-base';
import {
  StudentServiceProxy,
  StudentDto,
  StudentDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
import { CreateStudentDialogComponent } from './create-student/create-student-dialog.component';
import { EditStudentDialogComponent } from './edit-student/edit-student-dialog.component';

class PagedStudentesRequestDto extends PagedRequestDto {
  keyword: string;
}

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  animations: [appModuleAnimation()]
})

export class StudentComponent extends PagedListingComponentBase<StudentDto> {
    students: StudentDto[] = [];
    keyword = '';
    isActive: boolean | null;
    advancedFiltersVisible = false;
  
    constructor(
      injector: Injector,
      private _studentesService: StudentServiceProxy,
      private _modalService: BsModalService
    ) {
      super(injector);
    }
  
    list(
      request: PagedStudentesRequestDto,
      pageNumber: number,
      finishedCallback: Function
    ): void {
      request.keyword = this.keyword;
  
      this._studentesService
        .getAll(request.keyword, request.skipCount, request.maxResultCount)
        .pipe(
          finalize(() => {
            finishedCallback();
          })
        )
        .subscribe((result: StudentDtoPagedResultDto) => {
          this.students = result.items;
          this.showPaging(result, pageNumber);
        });
    }
  
    delete(student: StudentDto): void {
      abp.message.confirm(
        this.l('StudentDeleteWarningMessage', student.studentNumber),
        undefined,
        (result: boolean) => {
          if (result) {
            this._studentesService
              .delete(student.id)
              .pipe(
                finalize(() => {
                  abp.notify.success(this.l('SuccessfullyDeleted'));
                  this.refresh();
                })
              )
              .subscribe(() => {});
          }
        }
      );
    }
  
    createStudent(): void {
      this.showCreateOrEditStudentDialog();
    }
  
    editStudent(student: StudentDto): void {
      this.showCreateOrEditStudentDialog(student.id);
    }
  
    showCreateOrEditStudentDialog(id?: number): void {
      let createOrEditStudentDialog: BsModalRef;
      if (!id) {
        createOrEditStudentDialog = this._modalService.show(
          CreateStudentDialogComponent,
          {
            class: 'modal-lg',
          }
        );
      } else {
        createOrEditStudentDialog = this._modalService.show(
          EditStudentDialogComponent,
          {
            class: 'modal-lg',
            initialState: {
              id: id,
            },
          }
        );
      }
  
      createOrEditStudentDialog.content.onSave.subscribe(() => {
        this.refresh();
      });
    }
  }
  