import { Component } from '@angular/core';

import { MessageService } from '../../service/message.service';

@Component({
    selector: 'app-instructionscreen',
    templateUrl: './instructionscreen.component.html',
    styleUrls: ['./instructionscreen.component.css']
})

export class InstructionScreenComponent {
    constructor(public messageService: MessageService) {
        
    }
}
