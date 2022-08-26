import { Component, Injector, OnInit } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { StudentDto, StudentDtoPagedResultDto, StudentServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { CreateStudentComponent } from './create-student/create-student.component';
import { EditStudentComponent } from './edit-student/edit-student.component';

class PagedStudentsRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent extends PagedListingComponentBase<StudentDto> {
  students: StudentDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _studentService: StudentServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }
  createStudent(): void {
    this.showCreateOrEditStudentDialog();
  }

  editStudent(Student: StudentDto): void {
    this.showCreateOrEditStudentDialog(Student.id);
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }

  protected list(
    request: PagedStudentsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._studentService
      .getAll(
        request.keyword,
        request.skipCount,
        request.maxResultCount
      )
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

  protected delete(Student: StudentDto): void {
    abp.message.confirm(
      this.l('StudentDeleteWarningMessage', Student.studentNumber),
      undefined,
      (result: boolean) => {
        if (result) {
          this._studentService.delete(Student.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }


  private showCreateOrEditStudentDialog(id?: number): void {
    let createOrEditStudentDialog: BsModalRef;
    if (!id) {
      createOrEditStudentDialog = this._modalService.show(
        CreateStudentComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditStudentDialog = this._modalService.show(
        EditStudentComponent,
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
