import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { PersonDto, StudentDto, StudentServiceProxy, TagDto, TagServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Subject, Observable } from 'rxjs';
import { WebcamImage, WebcamInitError, WebcamUtil } from 'ngx-webcam';

@Component({
  selector: 'app-edit-student',
  templateUrl: './edit-student-dialog.component.html'
})
export class EditStudentDialogComponent extends AppComponentBase  
implements OnInit {
  saving = false;
  student: StudentDto = new StudentDto();
  id: number;
  tags: TagDto[];
  trigger: Subject<unknown> = new Subject();
  webcamImage!: WebcamImage;
  nextWebcam: Subject<unknown> = new Subject();

  captureImage  = '';

  @Output() onSave = new EventEmitter<any>();

  constructor(injector: Injector,
    public _studentService: StudentServiceProxy,
    public _tagService: TagServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
    this.student.person = new PersonDto();
  }

  ngOnInit(): void {
    this._studentService.get(this.id).subscribe((result) => {
      this.student = result;
      this._tagService.getDropdrownData().subscribe((result: TagDto[]) => {
        if(result != null)      
          this.tags = result;  
          //this.student.person.tagId 
      });

      this.captureImage = "data:" + this.student.person.logoImageType + ";base64," + this.student.person.logoImage;
      console.info('initial webcam image', this.captureImage);
    });
  }
  save(): void {
    this.saving = true;

    this._studentService.update(this.student).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }

/*------------------------------------------
    --------------------------------------------
    triggerSnapshot()
    --------------------------------------------
    --------------------------------------------*/
    public triggerSnapshot(): void {
      this.trigger.next();
  }

  /*------------------------------------------
  --------------------------------------------
  handleImage()
  --------------------------------------------
  --------------------------------------------*/
  public handleImage(webcamImage: WebcamImage): void {
      this.webcamImage = webcamImage;
      this.captureImage = webcamImage!.imageAsDataUrl;      
      console.info('received webcam image', this.captureImage);
      const myArray = this.captureImage.split(",");

      const text = myArray[0];
      this.student.person.logoImageType = myArray[0].substring(myArray[0].indexOf(":") + 1,myArray[0].indexOf(";"));
      this.student.person.logoImage = myArray[1];
      this.notify.info(this.l('Image captured...'));
  }

  /*------------------------------------------
  --------------------------------------------
  triggerObservable()
  --------------------------------------------
  --------------------------------------------*/
  public get triggerObservable(): Observable<unknown> {

      return this.trigger.asObservable();
  }

  /*------------------------------------------
  --------------------------------------------
  nextWebcamObservable()
  --------------------------------------------
  --------------------------------------------*/
  public get nextWebcamObservable(): Observable<unknown> {

      return this.nextWebcam.asObservable();
  }

}
